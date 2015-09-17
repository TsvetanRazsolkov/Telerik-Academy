namespace _01.Facade
{
    /// <summary>
    /// The facade class.
    /// </summary>
    public class BuildingSeller
    {
        private Financier finance = new Financier();
        private Architect architect = new Architect();
        private Engineer engineering = new Engineer();
        private Builder builder = new Builder();
        private Control control = new Control();

        public BuildingSeller InitiateTrade()
        {
            this.finance.MakeContract("client");
            this.finance.MakeContract("architect");
            this.finance.MakeContract("engineer");
            this.finance.MakeContract("builder");
            this.finance.MakeContract("controlling entity");

            return this;
        }

        public BuildingSeller BuildBuilding()
        {
            this.architect.DesignArchitecturalPlans();
            this.control.CertifyBuildingArchitecture();

            this.engineering.DesignConstructionPlans();
            this.engineering.ArgueWithArchitect();
            this.engineering.CalulateBuildingCost();
            this.control.CertifyBuildingConstruction();
            this.control.CertifyExpenses();

            this.builder.Build();
            this.control.ControlQuality();
            this.control.CertifyExpenses();

            this.finance.Pay("control");
            this.finance.Pay("architect");
            this.finance.Pay("engineer");
            this.finance.Pay("builder");

            return this;
        }

        public void Sell()
        {
            this.finance.SellBuilding();
        }
    }
}
