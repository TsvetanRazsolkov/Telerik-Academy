namespace DefiningClasses_Part1
{
    using System;

    class MainProgram
    {
        static void Main()
        {
            Console.WriteLine("GSM TESTING:");
            Console.WriteLine(GSMTest.TestGSM());

            Console.WriteLine("CALL HISTORY TESTING:");
            Console.WriteLine(GSMCallHistoryTest.TestGSMCalls());
        }
    }
}
