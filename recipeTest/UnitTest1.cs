using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using progPart2;

namespace RecipeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CaloriesCalculationTest()
        {

            var recipe = new Recipe("Test Recipe", 3, 3);



            recipe.GetIngredients(3); //  3 ingredients with known calorie values
            recipe.Ingredients[0].Calories = 100; // Ingredient 1 with 100 calories
            recipe.Ingredients[1].Calories = 200; // Ingredient 2 with 200 calories
            recipe.Ingredients[2].Calories = 100;  // Ingredient 3 with 100 calories

            // Act
            double totalCalories = CalculateTotalCalories(recipe.Ingredients);

            // Assert
            Assert.AreEqual(400, totalCalories); // Total calories should be 4000 (100 + 200 + 100)
        }

        private double CalculateTotalCalories(List<Ingredient> ingredients)
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }
}
