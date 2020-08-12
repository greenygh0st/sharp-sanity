using System;
using System.Threading.Tasks;
using SharpSanity;
using System.Collections.Generic;

namespace SharpSanity.Testing
{
    public static class RandomFail
    {
        public static bool WillItFail(int startRange = 1, int endRange = 5)
        {
            Random ran = new Random();
            int randomInt = ran.Next(startRange, endRange);
            if (Math.Floor(SaneMath.Median(new List<int> { startRange, endRange })) == randomInt)
            {
                throw new Exception("BOOM");
            } else
            {
                return true;
            }
        }

        public async static Task<bool> WillItFailAsync(int startRange = 1, int endRange = 5)
        {
            Random ran = new Random();
            int randomInt = await Task.FromResult(ran.Next(startRange, endRange));
            if (Math.Floor(SaneMath.Median(new List<int> { startRange, endRange })) == randomInt)
            {
                throw new Exception("BOOM");
            }
            else
            {
                return true;
            }
        }
    }
}
