namespace _02.Builder.Builders
{
    public abstract class WorkerBuilder
    {
        protected Worker Worker { get; set; }

        public abstract void CreateWorker();

        public abstract void TeachWorker();

        public abstract void TrainWorker();

        public abstract void CertifyWorker();

        public Worker GetWorker()
        {
            return this.Worker;
        }
    }
}
