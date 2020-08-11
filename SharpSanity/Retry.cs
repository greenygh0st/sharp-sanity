using System;
using System.Threading.Tasks;

namespace SharpSanity.Retry
{
    public static class Retry
    {
        public static async Task DoAsync(Func<Task> action, TimeSpan sleepPeriod, int tryCount = 3)
        {
            if (tryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(tryCount));

            int attempts = 0;

            while (true)
            {
                attempts++;
                try
                {
                    await action();
                    return; // success!
                }
                catch
                {
                    if (--tryCount == 0)
                        throw;

                    await Task.Delay(TimeSpan.FromMilliseconds(sleepPeriod.TotalMilliseconds * attempts));
                }
            }
        }
    }
}
