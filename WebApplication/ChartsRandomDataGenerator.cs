using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    /// <summary>
    /// Generates random data for the chart
    /// </summary>
    public static class ChartsRandomDataGenerator
    {
        public static IList<string> GenerateRandomDates(DateTime dateFrom, DateTime dateTo, int number)
        {
            var randomDateList = new List<string>();
            var random = new Random();
           
            var range = dateTo - dateFrom;

            int nbElements = 0;

            while (nbElements < number)
            {
                var randTimeSpan = new TimeSpan((long)(random.NextDouble() * range.Ticks));

                DateTime randomDate = dateFrom + randTimeSpan;

                //avoid to have twice the same value
                if (!randomDateList.Contains(randomDate.ToString("yyyy MMMM dd")))
                {
                    randomDateList.Add(randomDate.ToString("yyyy MMMM dd"));
                    nbElements++;
                }
            }
            return randomDateList.OrderBy(x => x).ToList();
        }

        public static IList<int> GenerateRandomNumbers(int range, int maxNumber)
        {
            var randomNumberList = new List<int>();
            var random = new Random();

            for (int counter = 0; counter < maxNumber; counter++)
            {
                int randomNumber = random.Next(range);
                randomNumberList.Add(randomNumber);
            }

            return randomNumberList;
        }
    }
}