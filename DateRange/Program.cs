using System;
using System.Globalization;

namespace DateRange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 2)
                {
                    DateTime firstDate = ParseDate(args[0]);
                    DateTime secendDate = ParseDate(args[1]);
                    Console.WriteLine(FormatRange(firstDate, secendDate));
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Program require 2 dates");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static DateTime ParseDate(string userInput)
        {
            DateTime parsedDate;
            string pattern = "dd.MM.yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                parsedDate = DateTime.ParseExact(userInput, pattern, provider, DateTimeStyles.None);
                return parsedDate;
            }
            catch (FormatException e)
            {
                throw new FormatException(e.Message);
            }
        }

        public static string FormatRange(DateTime firstDate, DateTime secendDate)
        {
            if (firstDate > secendDate)
            {
                DateTime temp = firstDate;
                firstDate = secendDate;
                secendDate = temp;
            }

            string dateRange = "";

            if (firstDate == secendDate)
            {
                dateRange = firstDate.ToString("dd.MM.yyyy");
            }
            else if (firstDate.Month == secendDate.Month && firstDate.Year == secendDate.Year)
            {
                dateRange = string.Format("{0} - {1}", firstDate.ToString("dd"), secendDate.ToString("dd.MM.yyyy"));
            }
            else if (firstDate.Year == secendDate.Year)
            {
                dateRange = string.Format("{0} - {1}", firstDate.ToString("dd.MM"), secendDate.ToString("dd.MM.yyyy"));
            }
            else
            {
                dateRange = string.Format("{0} - {1}", firstDate.ToString("dd.MM.yyyy"), secendDate.ToString("dd.MM.yyyy"));
            }
            return dateRange;
        }
    }
}
