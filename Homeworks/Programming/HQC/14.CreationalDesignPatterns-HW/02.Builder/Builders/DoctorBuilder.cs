namespace _02.Builder.Builders
{
    using System.Collections.Generic;

    public class DoctorBuilder : WorkerBuilder
    {
        public override void CreateWorker()
        {
            this.Worker = new Worker("Doctor");
        }

        public override void TeachWorker()
        {
            this.Worker.Skills.Add("Biology", "Very good.");
            this.Worker.Skills.Add("Chemistry", "Very good");
        }

        public override void TrainWorker()
        {
            this.Worker.Skills.Add("Surgery", "Very good.");
            this.Worker.Skills.Add("Neurology", "Very good");
        }

        public override void CertifyWorker()
        {
            this.Worker.Skills.Add("Medical MD diploma", "Finished medical school");
        }
    }
}