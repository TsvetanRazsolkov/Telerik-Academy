namespace _02.Builder.Builders
{
    using System.Collections.Generic;

    public class ProgrammerBuilder : WorkerBuilder
    {
        public override void CreateWorker()
        {
            this.Worker = new Worker("Programmer");
        }

        public override void TeachWorker()
        {
            this.Worker.Skills.Add("Math", "Good.");
            this.Worker.Skills.Add("Logic", "Good");
        }

        public override void TrainWorker()
        {
            this.Worker.Skills.Add(".NET Development", "Good.");
            this.Worker.Skills.Add("JavaScript development", "Good");
        }

        public override void CertifyWorker()
        {
            this.Worker.Skills.Add("Telerik Academy Certificate", "Completed on site courses");
        }
    }
}
