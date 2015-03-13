namespace DefiningClasses_Part1
{
    using System;
    using System.Text;

    public class GSMTest
    {
        public static string TestGSM()
        {
            StringBuilder result = new StringBuilder();

            GSM testOne = new GSM("Galaxy S5", "Samsung", 1000M, "Sasho", new Battery("Some model", 390, 21, BatteryType.Li_Ion),
                              new Display(5.1, 16000000));

            GSM testTwo = new GSM("Experia Z3", "Sony", 1000M, "Mustafa", new Battery("Some model", 790, 14, BatteryType.Li_Ion),
                                  new Display(5.2, 16000000));

            GSM testThree = new GSM("Lumia 535", "Microsoft", 1000M, "Asen", new Battery("Some model", 552, 11, BatteryType.Li_Ion),
                                  new Display(5, 16000000));

            GSM testFour = new GSM("Nexus", "Google");

            GSM[] testPhones = {testOne, testTwo, testThree, testFour, GSM.Iphone4s};

            foreach (var phone in testPhones)
            {
                result.AppendLine(phone + Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
