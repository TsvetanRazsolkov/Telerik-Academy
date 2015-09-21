namespace _07.Mediator
{
    using System.Collections.Generic;

    /// <summary>
    /// Concrete Coleague class
    /// </summary>
    public class Milan : FootballClub
    {
        public Milan(string name, ICollection<Player> players) : base(name, players)
        {
        }
    }
}
