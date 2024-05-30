using System;

namespace progPart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int ingredientCount = GetPositiveInteger("Please enter the number of ingredients:");
                int stepCount = GetPositiveInteger("Please enter the number of steps:");

                // Create a new Recipe instance with the specified number of ingredients and steps
                Recipe recipe = new Recipe(ingredientCount, stepCount);

                GetIngredients(recipe, ingredientCount);
                recipe.ReservedQuantities();
                GetSteps(recipe, stepCount);

                // Display the ingredients and steps of the recipe
                DisplayRecipe(recipe);

                while (true)
                {
                    ScaleRecipe(recipe);

                    Console.WriteLine("\nDo you want to scale the recipe again? (y/n)");
                    if (Console.ReadLine().ToLower() != "y")
                    {
                        break;
                    }
                }

                ResetQuantitiesIfRequested(recipe);
                ClearRecipeIfRequested(recipe);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }
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

        static void GetIngredients(Recipe recipe, int ingredientCount)
        {
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine("Enter ingredient name:");
                string name = Console.ReadLine();

                double quantity = GetPositiveDouble("Enter quantity:");

                Console.WriteLine("Enter unit of measurement:");
                string unit = Console.ReadLine();

                // Add the new Ingredient instance to the Ingredients array in the recipe
                recipe.Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }
        }

        static double GetPositiveDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive number.");
                Console.ResetColor();
            }
            return value;
        }

        static void GetSteps(Recipe recipe, int stepCount)
        {
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter the step {i + 1} description:");
                recipe.Steps[i] = Console.ReadLine();
            }
        }

        static void ScaleRecipe(Recipe recipe)
        {
            Console.WriteLine("\nEnter scaling factor (0.5, 2, or 3):");
            if (double.TryParse(Console.ReadLine(), out double factor) && (factor == 0.5 || factor == 2 || factor == 3))
            {
                recipe.Scale(factor);
                DisplayRecipe(recipe);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 for the scaling factor.");
                Console.ResetColor();
            }
        }

        static void ResetQuantitiesIfRequested(Recipe recipe)
        {
            Console.WriteLine("\nDo you want to reset quantities to original values? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                recipe.ResetQuantities();
                DisplayRecipe(recipe);
            }
        }

        static void ClearRecipeIfRequested(Recipe recipe)
        {
            Console.WriteLine("\nDo you want to clear all data to enter a new recipe? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                recipe.Clear();
            }
        }

        static void DisplayRecipe(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nIngredients:");
            Console.ResetColor();

            for (int i = 0; i < recipe.Ingredients.Length; i++)
            {
                Ingredient ingredient = recipe.Ingredients[i];
                Console.WriteLine($"  {i + 1}. {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSteps:");
            Console.ResetColor();

            for (int i = 0; i < recipe.Steps.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {recipe.Steps[i]}");
            }
        }
    }
}