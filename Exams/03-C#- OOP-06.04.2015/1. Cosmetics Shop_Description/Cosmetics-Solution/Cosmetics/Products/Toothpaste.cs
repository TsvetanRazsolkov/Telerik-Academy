
namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngredientNameLength = 4;
        private const int MaxIngredientNameLength = 12;
        private const string NullIngredientsErrorMessage = "List of ingredients can not be null.";

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = this.ParseIngredients(ingredients);
        }

        public string Ingredients
        {
            get { return this.ingredients; }
            private set
            {
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            var result = new StringBuilder();

            result.Append(base.Print());

            result.AppendFormat("{0}  * Ingredients: {1}", Environment.NewLine, this.Ingredients);
            
            return result.ToString();
        }

        private string ParseIngredients(IList<string> inputIngredients)
        {
            this.ValidateIngredientsInput(inputIngredients);

            string result = string.Join(", ", inputIngredients);
            return result;
        }

        private void ValidateIngredientsInput (IList<string> inputIngredients)
        {
            Validator.CheckIfNull(inputIngredients, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "List with toothpaste ingredients"));

            foreach (string ingredient in inputIngredients)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, MaxIngredientNameLength, MinIngredientNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", MinIngredientNameLength, MaxIngredientNameLength));
            }
        }
    }
}
