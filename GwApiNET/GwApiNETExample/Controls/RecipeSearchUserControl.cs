using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GwApiNET;
using GwApiNET.ResponseObjects;
using GwApiNETExample.Managers;

namespace GwApiNETExample.Controls
{
    public partial class RecipeSearchUserControl : UserControlBase
    {
        public RecipeSearchUserControl()
        {
            InitializeComponent();
            RecipeManager.Instance.StatusChanged += Instance_StatusChanged;
        }

        void Instance_StatusChanged(string status)
        {
            Status = status;
        }

        private const string downloadCountFormat = @"{0}/{1}";
        private Stopwatch watch = new Stopwatch();
        private async void buttonUpdateRecipes_Click(object sender, EventArgs e)
        {
            labelDownloadCount.Visible = true;
            progressBarDownload.Visible = true;
            labelTime.Visible = true;
            timer1.Start();
            watch.Start();
            await RecipeManager.Instance.DownloadRecipesAsync();
            watch.Stop();
            progressBarDownload.Visible = false;
            labelTime.Visible = false;
            labelDownloadCount.Visible = false;
            labelTotalRecipes.Text = "Known Recipes:" + RecipeManager.Recipes.Count.ToString();
            ComboBoxIdList.DataSource = RecipeManager.Recipes.Keys.ToArray();
            Status = "Recipes Updated";
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int count = RecipeManager.Instance.DownloadCount;
            int total = RecipeManager.Instance.TotalDownloadCount == 0 ? 1 : RecipeManager.Instance.TotalDownloadCount;
            if(labelDownloadCount.Visible)
                labelDownloadCount.Text = string.Format(downloadCountFormat, count, total);
            if(progressBarDownload.Visible)
                progressBarDownload.Value = 100 * count / total;
            if (labelTime.Visible)
                labelTime.Text = watch.Elapsed.TotalSeconds.ToString("0.000");

        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text;
            SearchResultsBox.Items.Clear();
            var result = await FindAsync(searchTerm);
            SearchResultsBox.Items.AddRange(result.ToArray());
            labelSearchCount.Text = "Results: " + SearchResultsBox.Items.Count;
        }

        private async Task<List<RecipeSearchResult>> FindAsync(string searchTerm)
        {
            var result = new List<RecipeSearchResult>(50);
            await Task<List<RecipeSearchResult>>.Run(() =>
                {
                    try
                    {
                        var recipes = RecipeManager.Recipes.AsParallel()
                                                   .Where(
                                                       r =>
                                                       ItemManager.Items.ContainsKey(r.Value.OutputItemId) &&
                                                       ItemManager.Items[r.Value.OutputItemId].Name.ToLower()
                                                                                             .Contains(searchTerm));
                        result.AddRange(recipes.Select(r => new RecipeSearchResult(r.Value)));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }).ConfigureAwait(false);
            return result;
        }
        internal class RecipeSearchResult : SearchResult
        {
            private readonly RecipeDetailsEntry _recipe;
            public override string DisplayValue
            {
                get { return ItemManager.Items[_recipe.OutputItemId].Name; }
            }
            public override object Id
            {
                get { return _recipe.RecipeId; }
            }
            public RecipeSearchResult(RecipeDetailsEntry recipe)
            {
                _recipe = recipe;
            }
        }

        internal class SearchResult
        {
            public virtual string DisplayValue { get; set; }
            public virtual object Id { get; set; }
            public SearchResult(){}
            public SearchResult(string displayVal, object id)
            {
                DisplayValue = displayVal;
                Id = id;
            }

            public override string ToString()
            {
                return DisplayValue;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        internal RecipeSearchResult SelectedResult { get { return SearchResultsBox.SelectedItem as RecipeSearchResult; } }

        private void SearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
