using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.ResponseObjects;

namespace GwApiNETExample.Managers
{
    /// <summary>
    /// This class is managed using a singleton.
    /// </summary>
    public class RecipeManager : ApiManagerBase
    {
        private static RecipeManager _instance;
        /// <summary>
        /// Manager instance
        /// </summary>
        public static RecipeManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RecipeManager();
                return _instance;
            }
        }
        /// <summary>
        /// Dictionary of known recipes keyed by recipe id.  These are mantained and persist using ResponseCache.
        /// use <seealso cref="DownloadRecipesAsync"/> to update this dictionary of recipes.
        /// </summary>
        public static EntryDictionary<int, RecipeDetailsEntry> Recipes { get; private set; }

        static RecipeManager()
        {
            
        }

        #region Download Status Info

        public int TotalDownloadCount = 0;
        public int DownloadCount = 0;

        #endregion Download Status Info

        public async Task CacheRecipesAsync()
        {
            await Task.Run(() => ResponseCache.Cache.Add("RecipeDictionary", Recipes)).ConfigureAwait(false);
        }
        /// <summary>
        /// Loads the known recipes from cache.
        /// </summary>
        /// <returns>dictionary of recipes obtained from cache</returns>
        public Task<EntryDictionary<int,RecipeDetailsEntry>> GetCachedRecipesAsync()
        {
            var tsk = new TaskCompletionSource<EntryDictionary<int, RecipeDetailsEntry>>();
            ThreadPool.QueueUserWorkItem(
                o =>
                tsk.TrySetResult(ResponseCache.Cache.Get("RecipeDictionary") as EntryDictionary<int, RecipeDetailsEntry>));
            return tsk.Task;
        }
        /// <summary>
        /// Downloads a complete list of available recipe ids.
        /// This is a full list of known recipe ids available via the GW2 API.
        /// </summary>
        /// <returns>IdList containing the ids</returns>
        public Task<IdList> DownloadCompleteIdListAsync()
        {
            TaskCompletionSource<IdList> tsk = new TaskCompletionSource<IdList>();
            ThreadPool.QueueUserWorkItem(o =>
                {
                    tsk.TrySetResult(GwApi.GetRecipeIds());
                });
            return tsk.Task;
        }
        /// <summary>
        /// Downloads and updates <seealso cref="Recipes"/> with any unknown recipes.
        /// <remarks><code>
        /// 1. Downloads a complete list of available recipe ids.
        /// 2. Compiles a list of unknown recipe ids.
        /// 3. Downloads the unknown recipes
        /// 4. Adds the new recipes to <seealso cref="Recipes"/>
        /// 5. Updates ResponseCache</code></remarks>
        /// </summary>
        /// <returns></returns>
        public async Task DownloadRecipesAsync()
        {
            // Load recipes from cache.
            // We can do this at the same time as some other operations so don't await
            Task<EntryDictionary<int,RecipeDetailsEntry>> loadCacheTask = GetCachedRecipesAsync();

            Status = "Downloading ID List";
            // get list of available recipes (id list)
            IdList idList = await DownloadCompleteIdListAsync().ConfigureAwait(false);
            // make sure the cache is finished loading.  The next task requires our loadCacheTask to be finished
            Recipes = await loadCacheTask.ConfigureAwait(false) ?? new EntryDictionary<int, RecipeDetailsEntry>();
            // get unknown id list;
            Status = "Determining unknown ids";
            IList<int> unknownIds = await GetUnknownIdsAsync(idList).ConfigureAwait(false);
            // download unknown ids;
            Status = "Downloading Unknown Recipes";
            EntryDictionary<int, RecipeDetailsEntry> recipes = await DownloadRecipesAsync(unknownIds).ConfigureAwait(false);
            // add new recipes to .Recipes
            Status = "Merging Unknown Recipes into Recipe Dictionary";
            await MergeRecipesAsync(recipes).ConfigureAwait(false);
            Status = "Recipe Dicitonary Updated";
            CacheRecipesAsync();
        }

        private Task MergeRecipesAsync(EntryDictionary<int, RecipeDetailsEntry> recipes)
        {
            Action<object> act = r =>
                {
                    Recipes.AddRange(r as EntryDictionary<int, RecipeDetailsEntry>);
                };
            var task = Task.Factory.StartNew(act, recipes);

            return task;
        }
        /// <summary>
        /// Download Recipes
        /// </summary>
        /// <param name="idlist">list of recipe ids to download</param>
        /// <returns>Dictionary of Recipes downloaded, keyed by the recipe id</returns>
        public Task<EntryDictionary<int, RecipeDetailsEntry>> DownloadRecipesAsync(IList<int> idlist)
        {
            var tsk = new TaskCompletionSource<EntryDictionary<int, RecipeDetailsEntry>>();
            var recipes = new EntryDictionary<int, RecipeDetailsEntry>();
            List<Exception> exceptions = new List<Exception>();
            ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        TotalDownloadCount = idlist.Count;
                        DownloadCount = 0;
                        foreach (var id in idlist)
                        {
                            try
                            {
                                var recipe = GwApi.GetRecipeDetails(id);
                                recipes.Add(id, recipe);
                                DownloadCount++;
                            }
                            catch (Exception e)
                            {
                                exceptions.Add(e);
                            }
                        }
                        tsk.TrySetResult(recipes);
                    }
                    catch (Exception e)
                    {
                        exceptions.Add(e);
                        tsk.TrySetException(e);
                    }
                });
            return tsk.Task;
        }

        /// <summary>
        /// compares a given list of recipe ids with the list of known recipes <seealso cref="Recipes"/>
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public Task<IList<int>> GetUnknownIdsAsync(IList<int> idlist)
        {
            var tsk = new TaskCompletionSource<IList<int>>();
            ThreadPool.QueueUserWorkItem(_getUnknownIdsProc,
                                         new Tuple
                                             <EntryDictionary<int, RecipeDetailsEntry>, IList<int>,
                                             TaskCompletionSource<IList<int>>>(Recipes, idlist, tsk));
            return tsk.Task;
        }

        // compiles a list of unknown ids
        // the result list is put into a TaskCompletionSource
        private void _getUnknownIdsProc(object o)
        {
            var tup = o as Tuple<EntryDictionary<int, RecipeDetailsEntry>, IList<int>, TaskCompletionSource<IList<int>>>;
            var tsk = tup.Item3;
            try
            {
                var unknownIds = _getUnknownIds(tup.Item1, tup.Item2);
                tsk.SetResult(unknownIds);
            }
            catch (Exception e)
            {
                tsk.SetException(e);
            }
        }

        /// <summary>
        /// Gets a recipe by its id.  If the recipe is not already in cache, it will be downloaded.
        /// An update can be forced by setting <paramref name="ignoreCache"/>=true.
        /// </summary>
        /// <param name="id">id of recipe to get.</param>
        /// <param name="ignoreCache">true: forces downloading the recipe allowing for a refresh of data. false: allow the recipe to be retrived from cache if it is available</param>
        /// <returns>recipe with the given id</returns>
        public async Task<RecipeDetailsEntry> GetRecipe(int id, bool ignoreCache = false)
        {
            RecipeDetailsEntry recipe = null;
            if (ignoreCache || Recipes.ContainsKey(id) == false)
            {
                await DownloadRecipe(id);
            }

            return Recipes.ContainsKey(id) ? Recipes[id] : null;
        }

        private Task<RecipeDetailsEntry> DownloadRecipe(int id)
        {
            var tsk = new TaskCompletionSource<RecipeDetailsEntry>();
            ThreadPool.QueueUserWorkItem(
                o =>
                    {
                        try
                        {
                            var recipe = GwApi.GetRecipeDetails(id);
                            Recipes[id] = recipe;
                            tsk.TrySetResult(recipe);
                        }
                        catch (Exception e)
                        {
                            tsk.TrySetException(e);
                        }
                    }
                );
            return tsk.Task;
        }

        /// <summary>
        /// Compiles a list of unknown ids
        /// </summary>
        /// <param name="knownRecipes">known recipes</param>
        /// <param name="idList">a list of recipe ids</param>
        /// <returns>list of recipe ids.  This is any id that is in <paramref name="idList"/> but not in <paramref name="knownRecipes"/></returns>
        private IList<int> _getUnknownIds(EntryDictionary<int,RecipeDetailsEntry> knownRecipes, IList<int> idList)
        {
            List<int> unknownIds = new List<int>();
            foreach (int id in idList)
            {
                if (knownRecipes.ContainsKey(id) == false)
                    unknownIds.Add(id);
            }
            return unknownIds;
        }
        private const string _defaultPropertyFormat = "{0}: {1}\n";

        public static async Task<string> GetRecipeString(RecipeDetailsEntry recipe)
        {
            return await Task.Run(
                async () =>
                    {
                        var sb = new StringBuilder();
                        try
                        {
                            var outputItem = await ItemManager.Instance.GetItem(recipe.OutputItemId);
                            sb.AppendFormat("{0}: {1} x{2}\n", "Name", outputItem.Name, recipe.OutputCount);
                            sb.AppendFormat(_defaultPropertyFormat, "Type", recipe.RecipeType);
                            sb.AppendFormat(_defaultPropertyFormat, "Skill Needed", recipe.MinRating);
                            sb.AppendFormat(_defaultPropertyFormat, "Craft Time(s)", recipe.TimeToCraftMsec / 1000.0);
                            sb.AppendLine("Diciplines:");
                            foreach (var dicipline in recipe.Diciplines)
                                sb.AppendFormat("  {0}", dicipline);
                            sb.AppendLine("Flags: " + string.Join(", ", recipe.Flags));
                            sb.AppendLine("Ingredients:");
                            foreach (var ingredient in recipe.Ingredients)
                                sb.AppendLine("  " + ingredient);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            sb.AppendLine("Error building details string for recipe id = " + recipe.OutputItemId);
                        }
                        return sb.ToString();
                    });
        }


        public static async Task<Bitmap> GetRecipeImage(RecipeDetailsEntry recipe)
        {
            return await Task.Run(
                async () =>
                    {
                        ItemDetailsEntry item = null;
                        try
                        {
                            item = await ItemManager.Instance.GetItem(recipe.OutputItemId).ConfigureAwait(false);
                            var rs = GwApi.GetRenderServiceAssetEntry(item.IconFileSignature, item.IconFileId, ".png");
                            return rs.Asset;
                        }
                        catch (Exception e)
                        {
                            int id = item != null ? item.ItemId : -1;
                            Debug.WriteLine(string.Format("For Item ID " + id + " - " + e));
                        }
                        return null;
                    });
        }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeManager()
        {
        }
    }
}
