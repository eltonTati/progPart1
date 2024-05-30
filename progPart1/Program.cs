using System;
using System.Collections.Generic;

namespace progPart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                try
                {
                    string recipeName = GetRecipeName();

                    int ingredientCount = GetPositiveInteger("Please enter the number of ingredients:");
                    int stepCount = GetPositiveInteger("Please enter the number of steps:");

                    Recipe recipe = new Recipe(recipeName, ingredientCount, stepCount);

                    recipe.GetIngredients(ingredientCount);
                    recipe.StoreOriginalQuantities();
                    recipe.GetSteps(stepCount);

                    recipes.Add(recipe);

                    // Display the ingredients and steps of the recipe
                    recipe.DisplayRecipe();

                    while (true)
                    {
                        recipe.ScaleRecipe();

                        Console.WriteLine("\nDo you want to scale the recipe again? (y/n)");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            break;
                        }
                    }

                    recipe.ResetQuantitiesIfRequested();

                    if (recipe.ClearRecipeIfRequested())
                    {
                        // If the user confirmed clearing the recipe, break the loop to enter a new recipe
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.ResetColor();
                }
            }

            // Display all recipes entered by the user
            Console.WriteLine("\nRecipes entered:");
            foreach (var recipe in recipes)
            {
                recipe.DisplayRecipe();
            }
        }

        static string GetRecipeName()
        {
            Console.WriteLine("Please enter the recipe name:");
            return Console.ReadLine();
        }

        static int GetPositiveInteger(string prompt)
        {
            int value;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.ResetColor();
            }
            return value;
        }
    }
}