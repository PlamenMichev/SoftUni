using System;
using System.Globalization;

namespace _05.DateModifier
{
    public class DateModifier
    {
        private double difference;

        public double Difference
        {
            get => this.difference;
            set => this.difference = value;
        }

        public double CalculatesDifference(string firstDate, string secDate)
        {
            DateTime firstDateAsDateTime = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secDateAsDateTime = DateTime.ParseExact(secDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            double difference = (firstDateAsDateTime - secDateAsDateTime).TotalDays;

            return difference;
        }
    }
}
