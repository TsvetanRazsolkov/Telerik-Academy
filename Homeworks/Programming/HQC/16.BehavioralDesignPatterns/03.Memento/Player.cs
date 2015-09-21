namespace _03.Memento
{
    public class Player
    {
        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }

        public Memento Save()
        {
            return new Memento(this.Name, this.Points);
        }

        public void Load(Memento memento)
        {
            this.Name = memento.Name;
            this.Points = memento.Points;
        }
    }
}
