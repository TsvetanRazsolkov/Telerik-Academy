namespace DefiningClasses_Part1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GSMCallHistoryTest
    {
        public const decimal CallPricePerMinute = 0.37M;

        public static string TestGSMCalls()
        {
            StringBuilder result = new StringBuilder();

            GSM testPhone = new GSM("Galaxy S5", "Samsung", 1000M, "Sasho", new Battery("Some model", 390, 21, BatteryType.Li_Ion),
                              new Display(5.1, 16000000));

            testPhone.AddCall(new Call(DateTime.Now, "+359888888888", 180));
            testPhone.AddCall(new Call(new DateTime(2010, 5, 12), "088888888888", 120));
            testPhone.AddCall(new Call(new DateTime(2012, 6, 7), "08877777777", 60));

            result.AppendLine("Phone calls in history: ");
            result.Append(testPhone.GetCallHistory());

            decimal totalPriceOfCalls = testPhone.CalculateTotalCallPrice(CallPricePerMinute);

            result.AppendFormat("Total price of calls in the history: {0:C}", totalPriceOfCalls);
            result.AppendLine(Environment.NewLine);

            Call longestCall = testPhone.CallHistory.OrderBy(x => x.CallDuration).LastOrDefault();
            testPhone.DeleteCall(longestCall);

            totalPriceOfCalls = testPhone.CalculateTotalCallPrice(CallPricePerMinute);
            result.AppendFormat("Total price of calls in the history after removing the longest call: {0:C}", totalPriceOfCalls);
            result.AppendLine(Environment.NewLine);

            testPhone.ClearCallHistory();
            result.AppendLine("Call history after deletion of all the calls: ");
            try
            {
                result.Append(testPhone.GetCallHistory());
            }
            catch (NullReferenceException exc)
            {
                result.AppendLine(exc.Message);
            }            

            return result.ToString();
        }
    }
}
