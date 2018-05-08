using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GwApiNET;
using GwApiNET.CacheStrategy;
using GwApiNET.ResponseObjects;
using GwApiNET.ResponseObjects.Parsers;
using NUnit.Framework;
using RestSharp;

namespace GwApiNETTest
{

    public class TestAuditor
    {
        public void CachePerformanceAddTest()
        {
            Stopwatch watch = new Stopwatch();
            var items = ResponseCache.Cache.Get("ItemsDictionary") as EntryDictionary<int, ItemDetailsEntry>;
            if (items == null) return;
            int count = 0;
            Console.WriteLine("Time to complete {0} {1}", count, watch.Elapsed.TotalSeconds.ToString("0.0000000"));
            watch.Start();
            foreach (var item in items)
            {
                ResponseCache.Cache.Add(item.Value);
                count++;
            }
            watch.Stop();
            Console.WriteLine("Time to complete {0} {1}", count, watch.Elapsed.TotalSeconds.ToString("0.0000000"));

        }


        public void CachePerformanceAddTest1()
        {
            Stopwatch watch = new Stopwatch();
            var items = ResponseCache.Cache.Get("ItemsDictionary") as EntryDictionary<int, ItemDetailsEntry>;

            if (items == null) return;
            int count = 0;
            Console.WriteLine("Time to complete {0} {1}", count, watch.Elapsed.TotalSeconds.ToString("0.0000000"));
            List<Task> addTask = new List<Task>();
            watch.Start();
            foreach (var item in items)
            {
                addTask.Add(ResponseCache.Cache.AddAsync(item.Value));
                count++;
            }
            Task.WaitAll(addTask.ToArray());
            watch.Stop();
            var time = watch.Elapsed;
            string output = string.Format("Time to complete {0} {1}", count,
                                          watch.Elapsed.TotalSeconds.ToString("0.0000000"));
            Console.WriteLine(output);

        }
        public void CachePerformanceLoadTest()
        {
            Stopwatch watch = new Stopwatch();
            var items = ResponseCache.Cache.Get("ItemsDictionary") as EntryDictionary<int, ItemDetailsEntry>;

            if (items == null) return;
            int count = 0;
            Console.WriteLine("Time to complete {0} {1}", count, watch.Elapsed.TotalSeconds.ToString("0.0000000"));
            List<Task<ItemDetailsEntry>> addTask = new List<Task<ItemDetailsEntry>>();
            watch.Start();
            var items2 = new EntryDictionary<int, ItemDetailsEntry>();
            foreach (var item in items)
            {
                var i = GwApi.GetItemDetails(item.Key);
                items2.Add(i.ItemId, i);
                count++;
            }
            watch.Stop();
            string output = string.Format("Time to complete {0} {1}", items2.Count,
                                          watch.Elapsed.TotalSeconds.ToString("0.0000000"));
            Console.WriteLine(output);

        }
        [Test]
        public void CachePerformanceLoadTest2()
        {
            Stopwatch watch = new Stopwatch();
            var items = ResponseCache.Cache.Get("ItemsDictionary") as EntryDictionary<int, ItemDetailsEntry>;

            if (items == null) return;
            int count = 0;
            Console.WriteLine("Time to complete {0} {1}", count, watch.Elapsed.TotalSeconds.ToString("0.0000000"));
            List<Task<ItemDetailsEntry>> addTask = new List<Task<ItemDetailsEntry>>();
            var items2 = new EntryDictionary<int, ItemDetailsEntry>();
            List<TimeSpan> times = new List<TimeSpan>();
            watch.Start();
            foreach (var item in items)
            {
                addTask.Add(GwApi.GetItemDetailsAsync(item.Key));
                count++;
            }
            var time = watch.Elapsed;
            Task.WaitAll(addTask.ToArray());
            foreach (var task in addTask)
            {
                items2.Add(task.Result.ItemId, task.Result);
            }
            watch.Stop();
            string output = string.Format("Time to complete {0} {1} {2}", items2.Count,
                                          watch.Elapsed.TotalSeconds.ToString("0.0000000"), time.TotalSeconds.ToString("0.0000000"));
            Console.WriteLine(output);
        }
        [Test]
        public void CachePerformanceLoadTest1()
        {
            Stopwatch watch = new Stopwatch();
            var items = ResponseCache.Cache.Get("ItemsDictionary") as EntryDictionary<int, ItemDetailsEntry>;
            if (items == null) return;
            var addTask = new List<Task<ItemDetailsEntry>>();
            var item1 = items[23651];
            ResponseCache.Cache.Remove(item1.Url);
            watch.Start();
            for (int i = 0; i < 10; i++)
            {
                addTask.Add(GwApi.GetItemDetailsAsync(item1.ItemId));
            }
            var time = watch.Elapsed;
            Thread.Sleep(1000);
            ResponseCache.Cache.Remove(item1.Url);
            //Task.WaitAll(addTask.ToArray());
            watch.Restart();
            for (int i = 0; i < 10; i++)
            {
                addTask.Add(GwApi.GetItemDetailsAsync(item1.ItemId));
            }
            var time1 = watch.Elapsed;
            //Task.WaitAll(addTask.ToArray());
            watch.Restart();
            for (int i = 0; i < 10; i++)
            {
                addTask.Add(GwApi.GetItemDetailsAsync(item1.ItemId));
            }
            var time2 = watch.Elapsed;
            Task.WaitAll(addTask.ToArray());
            var time3 = watch.Elapsed;
            watch.Stop();
            Console.WriteLine("{0}", time.TotalSeconds.ToString("0.0000000"));
            Console.WriteLine("{0}", time1.TotalSeconds.ToString("0.0000000"));
            Console.WriteLine("{0}", time2.TotalSeconds.ToString("0.0000000"));
            Console.WriteLine("{0}", time3.TotalSeconds.ToString("0.0000000"));
        }

        public void compare()
        {
            string[] readallExmample =
                File.ReadAllLines(
                    @"F:\My Documents\Visual Studio 2012\Projects\GwApiNET\GwApiNETExample\bin\Debug\Keys.txt");
            string[] readallTester = File.ReadAllLines("Keys.txt");
            List<string> different = new List<string>();
            foreach (var line in readallExmample)
            {
                if (readallTester.Contains(line) == false)
                    different.Add(line);
            }
            File.WriteAllLines("Differences", different);
        }
        public void requesttest()
        {
            var item = GwApi.GetItemDetails(39276, true);
            Console.WriteLine(item.TrinketDetails.SuffixId);

        }
        public void Test()
        {
            for (int i = 0; i < 16 * 16; i++)
            {
                Console.Write((i % 16) * 256 + " ");
                Console.WriteLine(((i/16)%(16*16) * 256));
            }
        }

        public Assembly Assembly { get; private set; }
        public List<string> NamedFilterList = new List<string>();

        public List<Tester.TestAuditInfoType> Tested
        {
            get { return All.Where(i => i.Status == TestedAttribute.TestStatus.Tested).ToList(); }
        }

        public List<Tester.TestAuditInfoType> Untested
        {
            get { return All.Where(i => i.Status == TestedAttribute.TestStatus.Untested).ToList(); }
        }


        public List<Tester.TestAuditInfoType> Ignored
        {
            get { return All.Where(i => i.Status == TestedAttribute.TestStatus.Ignored).ToList(); }
        }


        public List<Tester.TestAuditInfoType> Undocumented
        {
            get { return All.Where(i => i.Status == TestedAttribute.TestStatus.Undocumented).ToList(); }
        }


        public List<Tester.TestAuditInfoType> All = new List<Tester.TestAuditInfoType>();

        public void Audit(Assembly assembly)
        {
            Assembly = assembly;
            var typeList = assembly.GetTypes().ToList();
            foreach (Type type in typeList)
            {
                if (type.IsClass || (type.IsValueType && !type.IsEnum))
                {
                    var typeAttribute = type.GetCustomAttribute<TestedAttribute>(false);
                    All.Add(ProcessType(type, typeAttribute));
                }
            }
        }

        private Tester.TestAuditInfoType ProcessType(Type type, TestedAttribute typeAttribute)
        {
            Tester.TestAuditInfoType typeInfo = null;
            if (typeAttribute != null)
            {
                typeInfo = new Tester.TestAuditInfoType()
                    {
                        Name = type.Name,
                        TestReference = typeAttribute.TestReference,
                        TestDescription = typeAttribute.TestDescription,
                        Status = typeAttribute.Status,
                        ObjectType = type,
                    };

                var methods = type.GetMethods().ToList();
                foreach (var method in methods)
                {
                    if (method.IsPublic && !method.IsSpecialName && method.IsHideBySig)
                    {
                        // process method if it is public and not a property
                        processMethod(typeInfo, method);
                    }
                }

            }
            else
            {
                // undocumented, create info as needed
                typeInfo = new Tester.TestAuditInfoType()
                    {
                        Name = type.Name,
                        TestReference = "NA",
                        TestDescription = "No Test Attribute Defined",
                        Status = TestedAttribute.TestStatus.Untested,
                        ObjectType = type,
                    };
            }
            return typeInfo;
        }

        private void processMethod(Tester.TestAuditInfoType typeInfo, MethodInfo method)
        {
            if (method != null)
            {
                var methodAttribute = method.GetCustomAttribute<TestedAttribute>(false);
                if (methodAttribute != null)
                {
                    var info = getAuditInfo(method, methodAttribute);
                    switch (methodAttribute.Status)
                    {
                        case TestedAttribute.TestStatus.Tested:
                            typeInfo.TestedFunctions.Add(info);
                            break;
                        case TestedAttribute.TestStatus.Untested:
                            typeInfo.UntestedFunctions.Add(info);
                            break;
                        case TestedAttribute.TestStatus.Ignored:
                            typeInfo.IgnoredFunctions.Add(info);
                            break;
                    }
                }
                else
                {
                    typeInfo.UndocumentedFunctions.Add(new Tester.TestAuditInfo
                        {
                            Name = method.Name,
                            Status = TestedAttribute.TestStatus.Untested,
                            TestDescription = "Undocumented"
                        });
                }
            }
        }

        private Tester.TestAuditInfo getAuditInfo(MethodInfo method, TestedAttribute attribute)
        {
            return new Tester.TestAuditInfo
                {
                    Name = method.Name,
                    Status = attribute.Status,
                    TestDescription = attribute.TestDescription,
                    TestReference = attribute.TestReference
                };
        }

    }

    public class Tester
    {

        public void AuditTest()
        {
        }

        public class TestAuditInfoType : TestAuditInfo
        {
            public List<TestAuditInfo> TestedFunctions = new List<TestAuditInfo>();
            public List<TestAuditInfo> UntestedFunctions = new List<TestAuditInfo>();
            public List<TestAuditInfo> IgnoredFunctions = new List<TestAuditInfo>();
            public List<TestAuditInfo> UndocumentedFunctions = new List<TestAuditInfo>();
        }

        public class TestAuditInfo
        {
            public Type ObjectType { get; set; }
            public string Name { get; set; }
            public TestedAttribute.TestStatus Status { get; set; }
            public string TestDescription { get; set; }
            public string TestReference { get; set; }
        }

        public void test()
        {
            var assembly = Assembly.GetAssembly(typeof (TestedAttribute));
            var typeList = assembly.GetTypes().ToList();
            List<TestAuditInfoType> InfoTypes = new List<TestAuditInfoType>();
            foreach (Type type in typeList)
            {
                //var info = ProcessType(type);
                //if (info != null) InfoTypes.Add(info);
            }
            var temp =
                InfoTypes.Where(
                    i =>
                    i != null &&
                    (i.IgnoredFunctions.Count > 0 || i.UndocumentedFunctions.Count > 0 || i.UntestedFunctions.Count > 0 ||
                     i.TestedFunctions.Count > 0)).ToList();
        }


        public void examples()
        {
            GwApi.Network = new NetworkHandler();
            IdList list = GwApi.GetItemIds(true);
            Console.WriteLine("Total Items: {0}", list.Count);
        }



        public void DownloadItemDetails()
        {
            GwApi.Network = new NetworkHandler();
            var itemIds = GwApi.GetItemIds(true);
            string itemPath = @".\Items";
            Directory.CreateDirectory(itemPath);
            DirectoryInfo itemDir = new DirectoryInfo(itemPath);
            var downloadedItems = itemDir.GetFiles("*.txt");
            var downloadedIds = _parseItemFileIds(downloadedItems);
            List<string> itemDetails = new List<string>();
            Stopwatch watch = Stopwatch.StartNew();
            string fileNameFormat = itemPath + "\\{0}.txt";
            foreach (var id in itemIds)
            {
                if (downloadedIds.Contains(id) == false)
                {
                    string item = null;
                    try
                    {
                        ApiRequest request = new ApiRequest(Constants.item_details);
                        request.AddParameter("item_id", id);
                        item = GwApi.Network.GetResponse(request).ToString();
                        File.WriteAllText(string.Format(fileNameFormat, id), item);
                    }
                    catch (Exception)
                    {
                        File.AppendAllText(string.Format(fileNameFormat, "Failed_on"), id + "\n");
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("Finished in {0}s", watch.Elapsed.TotalSeconds);
            return;
        }

        private List<int> _parseItemFileIds(FileInfo[] downloadedItems)
        {
            List<int> itemIds = new List<int>();
            foreach (var fname in downloadedItems)
            {
                var tokens = fname.Name.Split(".".ToArray());
                int id;
                if (int.TryParse(tokens[0], out id)) itemIds.Add(id);
            }
            return itemIds;
        }

        public void DownloadAllRecipes()
        {
            GwApi.Network = new NetworkHandler();
            string path = ".\\Recipes\\";
            var ids = _getrecipeIds(path + "RecipeIds.txt");
            Stopwatch watch = Stopwatch.StartNew();
            foreach (var id in ids)
            {
                ApiRequest request = new ApiRequest(Constants.recipe_details);
                request.AddParameter("recipe_id", id);
                string json = "";
                try
                {
                    //json = GwApi.Network.GetResponse<string>(request);
                    File.WriteAllText(path + id.ToString() + ".txt", json);
                }
                catch (Exception)
                {
                    File.AppendAllText(string.Format("{0}{1}", path, "Failed_on.txt"), id + "\n");
                }
            }
            watch.Stop();
            Console.WriteLine("Finished in {0}s", watch.Elapsed.TotalSeconds);
        }

        private List<int> _getrecipeIds(string file)
        {
            string[] lines = File.ReadAllLines(file);
            var ids = new List<int>();
            foreach (var line in lines)
            {
                ids.Add(int.Parse(line));
            }
            return ids;
        }

        public void Test()
        {
            int build = GwApi.GetBuildNumber();
            GwApi.Network = new NetworkHandler();
            GwApi.GetColors(true);
            ResponseCache.Cache.Save();
        }
        public void Test1()
        {
            var files = GwApi.GetFiles();
            NetworkHandler handler = new NetworkHandler(Language.English, Constants.RenderServiceBaseUri);
            GwApi.RenderServiceNetwork = handler;
            foreach (var temp in files)
            {
                var file = GwApi.GetRenderServiceAssetEntry(temp.Value, ".png");
            }
        }

        public void ParseRecipes()
        {
            DirectoryInfo dir = new DirectoryInfo(@".\Recipes");
            var files = dir.GetFiles();
            List<RecipeType> types = new List<RecipeType>();
            List<DisciplineType> Disc = new List<DisciplineType>();
            int count = 0;
            foreach (var file in files)
            {
                var parser = new RecipeDetailsEntryParser();
                string[] tokens = file.Name.Split('.');
                int id = 0;
                if (int.TryParse(tokens[0], out id))
                {
                    //Console.WriteLine("Parsing {0}", file);
                    var recipe = parser.Parse(new RestResponse() { Content = File.ReadAllText(file.FullName) });
                    if (recipe != null)
                    {
                        count++;
                        types.Add(recipe.RecipeType);
                        Disc.AddRange(recipe.Diciplines);
                    }
                    else return;
                }
                else
                    Console.WriteLine("Skipping {0}", file);

            }
        }
        public void DownloadRecipes()
        {
            ResponseCache.Cache.Load("RecipeDetailsDictionary.bin");
            EntryDictionary<int, RecipeDetailsEntry> recipes =
                ResponseCache.Cache.Get("RecipeDetailsDictionary") as EntryDictionary<int, RecipeDetailsEntry> ??
                new EntryDictionary<int, RecipeDetailsEntry>();
            MockNetHandler handler = new MockNetHandler();
            var ids = GwApi.GetRecipeIds(true);
            ResponseCache.Cache.Save("RecipeDetailsDictionary.bin");
            GwApi.Network = handler;
            recipes.Url = "RecipeDetailsDictionary";
            foreach (var id in ids)
            {
                if (recipes.ContainsKey(id) == false)
                {
                    var recipe = GwApi.GetRecipeDetails(id);
                    recipes[recipe.RecipeId] = recipe;
                }
            }
            ResponseCache.Cache.Add("RecipeDetailsDictionary", recipes);
            ResponseCache.Cache.Save("RecipeDetailsDictionary.bin");
        }

        public class MockNetHandler : NetworkHandler
        {
            private NetworkHandler _netHandler;
            public MockNetHandler()
            {
                _netHandler = new NetworkHandler();
            }
            public override object GetResponse(IApiRequest request)
            {
                RestResponse response = new RestResponse();
                int id = (int)request.Parameters["recipe_id"];
                string filePath = @".\Recipes\" + id + ".txt";
                if (File.Exists(filePath))
                {
                    response.Content = File.ReadAllText(filePath);
                }
                else
                {
                    Debug.WriteLine(id + " not found, download from GW2");
                    response = _netHandler.GetResponse(request) as RestResponse;
                    File.WriteAllText(filePath, response.Content);
                }
                return response;
            }
        }


        public void LangTest()
        {
            NetworkHandler handler = new NetworkHandler();
            GwApi.Network = handler;
            var evennames = GwApi.GetEventNames(false, Language.German);
        }
    }


}
