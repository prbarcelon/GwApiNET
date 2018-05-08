using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class RecipeViewerUserControl : UserControlBase
    {
        public RecipeViewerUserControl()
        {
            InitializeComponent();
            recipeSearchUserControl1.ComboBoxIdList.SelectedValueChanged += ComboBoxIdList_SelectedValueChanged;
            recipeSearchUserControl1.SearchResultsBox.SelectedValueChanged +=SearchResultsBox_SelectedValueChanged;
        }

        async void ComboBoxIdList_SelectedValueChanged(object sender, EventArgs e)
        {
            int id = (int) recipeSearchUserControl1.ComboBoxIdList.SelectedValue;
            var recipe = await RecipeManager.Instance.GetRecipe(id);
            await SetRecipe(recipe).ConfigureAwait(false);
        }

        async void SearchResultsBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var recipe = RecipeManager.Recipes[(int)recipeSearchUserControl1.SelectedResult.Id];
                await SetRecipe(recipe).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public async Task SetRecipe(RecipeDetailsEntry recipe)
        {
            await recipeDetailsUserControl1.SetRecipe(recipe).ConfigureAwait(false);
        }

        public override string Status
        {
            get { return recipeSearchUserControl1.Status; }
        }
    }
}
