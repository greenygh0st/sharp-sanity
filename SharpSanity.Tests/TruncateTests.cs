using System;
using SharpSanity.Truncate;
using Xunit;

namespace SharpSanity.Tests
{
    public class TruncateTests
    {
        [Fact]
        public void DoesReturnEmptyStringIfEmpty()
        {
            string test = "";

            string result = test.Truncate(12);

            Assert.True(string.IsNullOrEmpty(result));
        }

        [Fact]
        public void DoesTruncate()
        {
            string test = "12345";

            string result = test.Truncate(2);

            Assert.Equal(2, result.Length);
        }
    }
}
