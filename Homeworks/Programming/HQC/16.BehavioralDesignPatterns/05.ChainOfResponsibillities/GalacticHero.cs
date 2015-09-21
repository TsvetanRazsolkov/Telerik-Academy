namespace _05.ChainOfResponsibillities
{
    /// <summary>
    /// Abstract Handler class
    /// </summary>
    public abstract class GalacticHero
    {
        public GalacticHero(string name, int strength)
        {
            this.Name = name;
            this.Strength = strength;
        }

        public string Name { get; set; }

        public int Strength { get; set; }

        protected GalacticHero Successor { get; set; }

        public void SetSuccessor(GalacticHero successor)
        {
            this.Successor = successor;
        }
        
        public abstract void DefeatVillain(Villain villain);
    }
}
