using System;
using Xunit;
using SharpSanity.Testing;
using System.Threading.Tasks;

namespace SharpSanity.Tests
{
    public class FailUnitTests
    {
        [Fact]
        public async Task WillFail()
        {
            try
            {
                await RandomFail.WillItFailAsync(1, 1);
                Assert.True(false); // should not ever get here
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }
}
