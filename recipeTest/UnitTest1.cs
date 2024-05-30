using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using progPart2;

namespace RecipeTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Unit test for testing calories calculation
        /// </summary>
        [TestMethod]
        public void CaloriesCalculationTest()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe", 3,1);
            recipe.Ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Ingredient1", Quantity = 1, Unit = "Unit1", Calories = 100, FoodGroup = "Group1" },
                new Ingredient { Name = "Ingredient2", Quantity = 1, Unit = "Unit2", Calories = 200, FoodGroup = "Group2" },
                new Ingredient { Name = "Ingredient3", Quantity = 1, Unit = "Unit3", Calories = 100, FoodGroup = "Group3" }
            };

            // Act
            double totalCalories = CalculateTotalCalories(recipe.Ingredients);

            // Assert
            Assert.AreEqual(400, totalCalories);
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
