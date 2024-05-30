using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Elton Tati
/// ST10158190
/// PROGRAMMING PART 2
/// </summary>
namespace progPart2

{
    public class Program
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

                    //Total calorires warning 
                    recipe.CaloriesExceeded += (name, totalCalories) =>
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"WARNING: The total calories of recipe '{name}' exceed 300. Total Calories: {totalCalories}");
                        Console.ResetColor();
                    };

                    recipe.GetIngredients(ingredientCount);
                    recipe.StoreOriginalQuantities();
                    recipe.GetSteps(stepCount);

                    recipes.Add(recipe);

                    // Display the details of the recipe 
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

                    if (recipe.AddNewRecipe())
                    {
                        // break the loop to enter a new recipe
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
            // Display all recipes entered by the user in alphabetical order by name
            Console.WriteLine("\nRecipes entered (sorted by name):");
            int recipeNumber = 1;
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine($"{recipeNumber}. {recipe.Name}");
                recipeNumber++;
            }

            while (true)
            {
                if (recipes.Count > 0)
                {
                    // Ask the user to choose a recipe to display
                    Console.WriteLine("\nEnter the number of the recipe you want to display (0 to exit):");
                    int selectedRecipeNumber = GetSelectedRecipeNumber(recipes.Count);

                    if (selectedRecipeNumber == 0)
                    {
                        // Exit the loop if the user chooses to exit
                        break;
                    }

                    // Display the selected recipe
                    recipes[selectedRecipeNumber - 1].DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("\nNo recipes entered.");
                    break;
                }
            }
        }
        //This method is to ask the recipe name 
        static string GetRecipeName()
        {
            Console.WriteLine("Please enter the recipe name:");
            return Console.ReadLine();
        }

        //This method ensures that the user enters a positive integer 
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

        //This method allows the user to select a recipe number 
        static int GetSelectedRecipeNumber(int maxNumber)
        {
            int value;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0 && value <= maxNumber)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid input. Please enter a number between 0 and {maxNumber}.");
                Console.ResetColor();
            }
            return value;
        }
    }
}

