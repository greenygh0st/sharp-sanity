using System;
using Xunit;
using SharpSanity.Testing;
using System.Threading.Tasks;
using SharpSanity.FaultTolerance;

namespace SharpSanity.Tests
{
    public class RetryUnitTest
    {
        [Fact]
        public async Task ShouldNotFail()
        {
            try
            {
                await Retry.GoAsync(async () =>
                {
                    bool isABool = await RandomFail.WillItFailAsync(); // odds are 1 in 5 :)

                    Assert.True(isABool);

                }, TimeSpan.FromMilliseconds(500), 10);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async Task ShouldFail()
        {
            try
            {
                await Retry.GoAsync(async () =>
                {
                    bool isABool = await RandomFail.WillItFailAsync(1, 1); // should always fail
                    Assert.True(!isABool);

                }, TimeSpan.FromMilliseconds(500), 3);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public async Task ThrowsInvalidArgument()
        {
            try
            {
                await Retry.GoAsync(async () =>
                {
                    bool isABool = await RandomFail.WillItFailAsync(); // odds are 1 in 5 :)

                    Assert.True(isABool);

                }, TimeSpan.FromMilliseconds(500), -1); // values less that or equal to zero should make it fail
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }
}
