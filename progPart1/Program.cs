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
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the number of Steps:");
            int stepCount = int.Parse(Console.ReadLine());

            Recipe recipe = new Recipe(ingredientCount, stepCount);

            try
            {
                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine("Enter ingredient name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter quantity:");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter unit of measurement:");
                    string unit = Console.ReadLine();

                    recipe.Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1} description:");
                recipe.Steps[i] = Console.ReadLine();
            }

            recipe.Disp();

            Console.WriteLine("\nEnter scaling factor (0.5, 2, or 3):");
            double factor = double.Parse(Console.ReadLine());
            recipe.Scale(factor);

            recipe.Disp();

            Console.WriteLine("\nDo you want to reset quantities to original values? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                recipe.ResetQuantities();
                recipe.Disp();
            }

            Console.WriteLine("\nDo you want to clear all data to enter a new recipe? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                recipe.Clear();
            }
        }
    }
}
