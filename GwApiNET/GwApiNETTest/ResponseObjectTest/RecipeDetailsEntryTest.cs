using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GwApiNETTest.ResponseObjectTest
{

    public class RecipeDetailsEntryTest
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeDetailsEntryTest()
        {
        }
        [Test]
        public void ToStringTest()
        {
            var recipe = GwApiNET.GwApi.GetRecipeDetails(1275);
            Console.WriteLine(recipe.ToString());
        }
    }
}
