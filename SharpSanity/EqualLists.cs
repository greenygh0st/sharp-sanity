using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpSanity.Linq
{
    public static class EqualListsStatic
    {
        /// <summary>
        /// Checks to see if all of the numbers in the list are the same
        /// </summary>
        /// <param name="source"></param>
        /// <returns>True if true, otherwise false</returns>
        public static bool EqualItemCount(this List<int> source)
        {
            double average = source.Average();

            bool even = Math.Abs(average % 1) <= (Double.Epsilon * 100) && source.Min() == source.Max();
            return even;
        }
    }
}
