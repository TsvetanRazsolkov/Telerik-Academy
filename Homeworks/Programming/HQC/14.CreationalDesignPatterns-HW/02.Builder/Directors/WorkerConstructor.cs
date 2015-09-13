namespace _02.Builder.Directors
{
    using Builders;

    public class WorkerConstructor
    {
        public Worker Construct(WorkerBuilder workerBuilder)
        {
            workerBuilder.CreateWorker();
            workerBuilder.TeachWorker();
            workerBuilder.TrainWorker();
            workerBuilder.CertifyWorker();

            return workerBuilder.GetWorker();
        }
    }
}
