using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpSanity.FaultTolerance
{
    public static class Retry
    {
        public static async Task GoAsync(Func<Task> action, TimeSpan sleepPeriod, int tryCount = 5)
        {
            List<Exception> exceptions = new List<Exception>();

            if (tryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(tryCount));

            int attempts = 0;

            while (true)
            {
                attempts++;
                try
                {
                    await action();
                    return;
                }
                catch (Exception ex)
                {
                    // keep a list of all the exceptions (cause they might be different)
                    exceptions.Add(ex);

                    // if we have run out of tries then error out
                    if (--tryCount == 0)
                        throw new AggregateException(exceptions);

                    await Task.Delay(TimeSpan.FromMilliseconds(sleepPeriod.TotalMilliseconds * attempts));
                }
            }
        }
    }
}
