using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace progPart1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // asking the user to enter the number of ingredients
            Console.WriteLine("Please enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());

            // asking the user to enter the number of steps
            Console.WriteLine("Please enter the number of Steps:");
            int stepCount = int.Parse(Console.ReadLine());

            // Create a new Recipe instance with the specified number of ingredients and steps
            Recipe recipe = new Recipe(ingredientCount, stepCount);

            try
            {
                // this Loop goes through each ingredient to get its name, quantity, and unit of measurement

                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine("Enter ingredient name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter quantity:");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter unit of measurement:");
                    string unit = Console.ReadLine();

                    // this is to add the new Ingredient instance to the Ingredients array in the recipe
                    recipe.Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
                }
            }
            catch (FormatException)
            {
                // Handle the case where the user enters an invalid input format for quantity
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            // Loop through each step to get its description
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1} description:");
                recipe.Steps[i] = Console.ReadLine();
            }
            // Display the ingredients and steps of the recipe
            recipe.Disp();

            // asking the user to enter a scaling factor and scale the recipe if valid
            Console.WriteLine("\nEnter scaling factor (0.5, 2, or 3):");
            double factor = double.Parse(Console.ReadLine());
            recipe.Scale(factor);

            // Display the scaled recipe
            recipe.Disp();

            // asking the user to reset quantities to original values and reset if requested
            Console.WriteLine("\nDo you want to reset quantities to original values? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                recipe.ResetQuantities();
                recipe.Disp();
            }

            //asking the user to clear all data to enter a new recipe and clear if requested

            Console.WriteLine("\nDo you want to clear all data to enter a new recipe? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                recipe.Clear();
            }
        }
    }
}
