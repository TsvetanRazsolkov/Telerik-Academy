namespace _03.Memento
{
    using System.Collections.Generic;

    /// <summary>
    /// The Caretaker class
    /// </summary>
    public class GameMemory
    {
        public GameMemory()
        {
            this.Saves = new Dictionary<string, Memento>();
        }

        public IDictionary<string, Memento> Saves { get; set; }
    }
}
