namespace PrintingVariable
{
    using System;

    public class VariablePrinter
    {
        public void PrintVariable(bool variableValue)
        {
            string variableValueAsString = variableValue.ToString();
            Console.WriteLine(variableValue);
        }
    }
}