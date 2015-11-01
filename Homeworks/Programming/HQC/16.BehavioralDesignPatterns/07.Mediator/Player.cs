namespace _07.Mediator
{
    public class Player
    {
        public Player(string name, int age, int speed, int technique, int price)
        {
            this.Name = name;
            this.Age = age;
            this.Speed = speed;
            this.Technique = technique;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Speed { get; set; }

        public int Technique { get; set; }

        public int Price { get; set; }

        public FootballClub Club { get; set; }
    }
}
