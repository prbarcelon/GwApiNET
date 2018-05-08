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
    public partial class RecipeDetailsUserControl : UserControlBase
    {
        public RecipeDetailsUserControl()
        {
            InitializeComponent();
        }

        public async Task SetRecipe(RecipeDetailsEntry recipe)
        {
            ItemDetailsEntry item = null;
            Bitmap image = null;
            string details = await Task.Run<string>(async () =>
                {
                    try
                    {
                        var itemTask = ItemManager.Instance.GetItem(recipe.OutputItemId).ConfigureAwait(false);
                        var detailTask = RecipeManager.GetRecipeString(recipe);
                        var imageTask = RecipeManager.GetRecipeImage(recipe);
                        item = await itemTask;
                        image = await imageTask;
                        return await detailTask;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return "Error occured\n";
                });
            labelRecipeDetails.Text = details;
            labelRecipeName.Text = item != null ? item.Name : "Error Getting Item Details";
            pictureBox1.Image = image;
        }
    }
}
