namespace _01.Facade
{
    using System;

    public class Financier
    {
        public void MakeContract(string party)
        {
            Console.WriteLine("Contract was made with {0}.", party);
        }

        public void SellBuilding()
        {
            Console.WriteLine("Building was sold.");
        }

        public void Pay(string employee)
        {
            Console.WriteLine("Paying {0}", employee);
        }
    }
}
