using progPart2;
using System.Collections.Generic;
using System;

namespace progPart2
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        private List<string> Steps { get; set; }
        private List<double> OriginalQuantities { get; set; }
        private List<string> OriginalUnits { get; set; }

        //private delegate void ScaleDelegate(double factor);
        private delegate void ResetDelegate();
        public delegate void ScaleDelegate(double factor);

        // Delegate definition for notifying when the total calories exceed 300
        public delegate void CaloriesExceededEventHandler(string recipeName, double totalCalories);

        // Event to be triggered when the total calories exceed 300
        public event CaloriesExceededEventHandler CaloriesExceeded;
        public Recipe(string name, int ingredientCount, int stepCount)
        {
            Name = name;
            Ingredients = new List<Ingredient>(ingredientCount);
            OriginalQuantities = new List<double>(ingredientCount);
            OriginalUnits = new List<string>(ingredientCount);
            Steps = new List<string>(stepCount);
        }
        public void GetIngredients(int ingredientCount)
        {
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1} details:");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                double quantity = GetPositiveDouble("Quantity:");

                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                double calories = GetPositiveDouble("Calories:");

                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            }
        }
        public double GetPositiveDouble(string prompt)
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

        public void GetSteps(int stepCount)
        {
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter the step {i + 1} description:");
                Steps.Add(Console.ReadLine());
            }
        }
        public void ScaleRecipe()
        {
            double factor = 0;
            ScaleDelegate scale = delegate (double f)
            {
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    Ingredients[i].Quantity *= f;
                }
            };

            Console.WriteLine("\nEnter scaling factor (0.5, 2, or 3):");
            if (double.TryParse(Console.ReadLine(), out factor) && (factor == 0.5 || factor == 2 || factor == 3))
            {
                scale(factor);
                DisplayRecipe();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 for the scaling factor.");
                Console.ResetColor();
            }
        }

        public void ResetQuantitiesIfRequested()
        {
            ResetDelegate reset = delegate ()
            {
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    Ingredients[i].Quantity = OriginalQuantities[i];
                    Ingredients[i].Unit = OriginalUnits[i];
                }
            };

            Console.WriteLine("\nDo you want to reset quantities to original values? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                reset();
                DisplayRecipe();
            }
        }


        public bool ClearRecipeIfRequested()
        {
            Console.WriteLine("\nDo you want to enter a new recipe? (y/n)");
            if (Console.ReadLine().ToLower() == "n")
            {
                return true;

            }
            Console.WriteLine("You can now enter a new recipe.");
            return false;
        }


        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nRecipe Name: {Name}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nIngredients:");
            Console.ResetColor();

            double totalCalories = 0;

            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredient ingredient = Ingredients[i];
                Console.WriteLine($"  {i + 1}. {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
                totalCalories += ingredient.Calories;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTotal Calories: {totalCalories}");
            Console.ResetColor();

            // Trigger the event if total calories exceed 300
            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(Name, totalCalories);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSteps:");
            Console.ResetColor();

            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {Steps[i]}");
            }
        }

        public void StoreOriginalQuantities()
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                OriginalQuantities.Add(Ingredients[i].Quantity);
                OriginalUnits.Add(Ingredients[i].Unit);
            }
        }
    }
}