using System;

namespace progPart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Asking the user to enter the number of ingredients
                Console.WriteLine("Please enter the number of ingredients:");
                if (!int.TryParse(Console.ReadLine(), out int ingredientCount) || ingredientCount < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the number of ingredients.");
                    return;
                }

                // Asking the user to enter the number of steps
                Console.WriteLine("Please enter the number of steps:");
                if (!int.TryParse(Console.ReadLine(), out int stepCount) || stepCount < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the number of steps.");
                    return;
                }

                // Create a new Recipe instance with the specified number of ingredients and steps
                Recipe recipe = new Recipe(ingredientCount, stepCount);

                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine("Enter ingredient name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter quantity:");
                    if (!double.TryParse(Console.ReadLine(), out double quantity) || quantity < 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number for quantity.");
                        i--; // Stay on the same ingredient
                        continue;
                    }

                    Console.WriteLine("Enter unit of measurement:");
                    string unit = Console.ReadLine();

                    // Add the new Ingredient instance to the Ingredients array in the recipe
                    recipe.Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
                }

                for (int i = 0; i < stepCount; i++)
                {
                    Console.WriteLine($"Enter the step {i + 1} description:");
                    recipe.Steps[i] = Console.ReadLine();
                }

                // Display the ingredients and steps of the recipe
                recipe.Disp();

                // Asking the user to enter a scaling factor and scale the recipe if valid
                Console.WriteLine("\nEnter scaling factor (0.5, 2, or 3):");
                if (!double.TryParse(Console.ReadLine(), out double factor) || (factor != 0.5 && factor != 2 && factor != 3))
                {
                    Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 for the scaling factor.");
                }
                else
                {
                    recipe.Scale(factor);
                    recipe.Disp();
                }

                // Asking the user to reset quantities to original values and reset if requested
                Console.WriteLine("\nDo you want to reset quantities to original values? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    recipe.ResetQuantities();
                    recipe.Disp();
                }

                // Asking the user to clear all data to enter a new recipe and clear if requested
                Console.WriteLine("\nDo you want to clear all data to enter a new recipe? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    recipe.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
