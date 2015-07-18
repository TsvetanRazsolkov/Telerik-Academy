namespace VariablesExpressionsConstants
{
    using System;

    public class StatisticsPrinter
    {
        public void PrintStatistics(double[] numbersCollection, int countOfElementsToUse)
        {
            double max = this.GetMax(numbersCollection, countOfElementsToUse);
            this.PrintStatistic(max);

            double min = this.GetMin(numbersCollection, countOfElementsToUse);
            this.PrintStatistic(min);

            double sum = this.GetSum(numbersCollection, countOfElementsToUse);
            double average = sum / countOfElementsToUse;
            this.PrintStatistic(average);
        }

        private double GetMax(double[] numbersCollection, int countOfElementsToUse)
        {
            double max = numbersCollection[0];
            for (int i = 1; i < countOfElementsToUse; i++)
            {
                if (numbersCollection[i] > max)
                {
                    max = numbersCollection[i];
                }
            }

            return max;
        }

        private double GetMin(double[] numbersCollection, int countOfElementsToUse)
        {
            double min = numbersCollection[0];
            for (int i = 1; i < countOfElementsToUse; i++)
            {
                if (numbersCollection[i] < min)
                {
                    min = numbersCollection[i];
                }
            }

            return min;
        }

        private double GetSum(double[] numbersCollection, int countOfElementsToUse)
        {
            double sum = numbersCollection[0];
            for (int i = 1; i < countOfElementsToUse; i++)
            {
                sum += numbersCollection[i];
            }

            return sum;
        }

        private void PrintStatistic(double statistic)
        {
            throw new NotImplementedException();
        }
    }
}
