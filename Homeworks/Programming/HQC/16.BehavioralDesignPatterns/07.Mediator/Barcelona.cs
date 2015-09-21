namespace _07.Mediator
{
    using System.Collections.Generic;

    /// <summary>
    /// Concrete Coleague class
    /// </summary>
    public class Barcelona : FootballClub
    {
        public Barcelona(string name, ICollection<Player> players) : base(name, players)
        {
        }
    }
}
