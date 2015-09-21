namespace _03.Memento
{
    /// <summary>
    /// The 'Memento' class
    /// </summary>
    public class Memento
    {
        public Memento(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}
