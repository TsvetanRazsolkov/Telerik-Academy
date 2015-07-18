namespace ClassChefInCSharp
{
    using ClassChefInCSharp.CookingPoducts;
    using ClassChefInCSharp.CookingUtensils;

    public class Chef
    {
        public Chef()
        {
        }
        
        public void Cook()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
            bowl.Cook();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.IsCut = true;
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.IsPeeled = true;
        }
    }
}
