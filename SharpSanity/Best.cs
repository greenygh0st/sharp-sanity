using System;
namespace SharpSanity.BestText
{
    public static class Best
    {
        /// <summary>
        /// Returns the best possible text output for the provided Timespan
        /// </summary>
        /// <param name="timespan">Current <see cref="TimeSpan"/></param>
        /// <param name="precision">Number of decimal points to display</param>
        /// <returns><see cref="string"/> representation of the timespan</returns>
        public static string BestText(this TimeSpan timespan, int precision = 2)
        {
            double ms = Math.Round(timespan.TotalMilliseconds);

            if (ms > 0 && ms < 1000)
            {
                return $"{ms} milliseconds";
            }
            else if (ms == 1000)
            {
                return "1 second";
            }
            else if (ms > 1000 && ms < (60 * 1000)) // greater than a second but less than a minute
            {
                return $"{Math.Round(ms / 1000, precision)} seconds";
            }
            else if (ms == (60 * 1000))
            {
                return "1 minute";
            }
            else if (ms > (60 * 1000) && ms < (60 * 60 * 1000)) // greater than one minute but less than an hour
            {
                return $"{Math.Round(ms / (60 * 1000), precision)} minutes";
            }
            else if (ms == (60 * 60 * 1000))
            {
                return $"1 hour";
            }
            else if (ms > (60 * 60 * 1000) && ms < (24 * 60 * 60 * 1000))
            {
                // greater than 1 hour but less than a day
                return $"{Math.Round(ms / (60 * 60 * 1000), precision)} hours";
            }
            else if (ms == (24 * 60 * 60 * 1000))
            {
                return "1 day";
            }
            else if (ms > (24 * 60 * 60 * 1000))
            {
                return $"{Math.Round(ms / (24 * 60 * 60 * 1000), precision)} days";
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
