namespace ClassChefInCSharp.CookingUtensils
{
    using System;
    using System.Collections.Generic;

    using ClassChefInCSharp.CookingPoducts;
    
    public class Bowl
    {
        private IList<Vegetable> vegetables;

        public Bowl()
        {
            this.Vegetables = new List<Vegetable>();
        }

        public IList<Vegetable> Vegetables
        {
            get
            {
                return new List<Vegetable>(this.vegetables);
            }

            private set
            {
                this.vegetables = value;
            }
        }

        public void Add(Vegetable vegetable)
        {
            if (vegetable == null)
            {
                throw new NullReferenceException("Vegetable to add cannot be null");
            }

            this.vegetables.Add(vegetable);
        }

        public void Cook()
        {
            foreach (var vegetable in this.Vegetables)
            {
                vegetable.IsCooked = true;
            }
        }
    }
}
