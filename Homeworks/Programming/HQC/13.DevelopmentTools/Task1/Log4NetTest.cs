namespace Task1
{
    using log4net;
    using log4net.Config;

    /// <summary>
    /// Test class for the Log4Net namespace.
    /// </summary>
    public class Log4NetTest
    {
        /// <summary>
        /// The only instance of Logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Log4NetTest));

        /// <summary>
        /// The entry point of our program.
        /// </summary>
        public static void Main()
        {
            BasicConfigurator.Configure();

            Logger.Info("Info log");
            Logger.Error("Error log");
            Logger.Warn("Warn log");
            Logger.Fatal("Fatal log");
        }
    }
}
