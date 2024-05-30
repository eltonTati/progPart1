using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progPart1
{
    internal class Recipe
    {

        public Ingredient[] Ingredients { get; set; } // Array to store ingredients
        public string[] Steps { get; set; } // Array to store steps
        private double[] FirstQuant { get; set; } // Array to store original quantities of ingredients
        private string[] FirstUnits { get; set; }

        // Constructor to initialize the arrays based on the number of ingredients and steps
        public Recipe(int ingredientCount, int stepCount)
        {
            Ingredients = new Ingredient[ingredientCount];
            FirstQuant = new double[ingredientCount];
            FirstUnits = new string[ingredientCount];
            Steps = new string[stepCount];
        }

        // This method is to display the ingredients and steps of the recipe
        public void Disp()
        {
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        // Scale the quantities of ingredients by a given factor
        public void Scale(double factor)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity *= factor;
            }
        }

        // I created this method to reset the quantities of ingredients to their original values
        public void ResetQuantities()
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity = FirstQuant[i];
                Ingredients[i].Unit = FirstUnits[i];
            }
        }

         // I created this method to clear all ingredients and steps from the recipe
         public void Clear()
        {
            Array.Clear(Ingredients, 0, Ingredients.Length);
            Array.Clear(Steps, 0, Steps.Length);
        }
        
        // I created this method as a backup of the original quantities of ingredients to the OriginalQuantities dictionary

        public void ReservedQuantities()
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                FirstQuant[i] = Ingredients[i].Quantity;
                FirstUnits[i] = Ingredients[i].Unit;
            }
        }
    }
}
