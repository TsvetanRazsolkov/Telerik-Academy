namespace _03.Proxy
{
    using System.Collections.Generic;

    public class Player
    {
        public Player(string name, IDictionary<string, int> resources)
        {
            this.Name = name;
            this.Resources = new Dictionary<string, int>(resources);
        }

        public string Name { get; set; }

        public IDictionary<string, int> Resources { get; set; }
    }
}
