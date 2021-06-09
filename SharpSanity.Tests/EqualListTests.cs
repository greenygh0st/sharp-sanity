using System;
using System.Collections.Generic;
using SharpSanity.Linq;
using Xunit;

namespace SharpSanity.Tests
{
    public class EqualListTests
    {
        [Fact]
        public void IsEven()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4 };
            List<int> list2 = new List<int> { 1, 2, 3, 6 };
            List<string> list3 = new List<string> { "john", "ted", "fred", "susan" };

            List<int> even = new List<int> { list1.Count, list2.Count, list3.Count };

            Assert.True(even.EqualItemCount());
        }

        [Fact]
        public void IsNotEven()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4 };
            List<int> list2 = new List<int> { 1, 2, 3, 6 };
            List<string> list3 = new List<string> { "john", "ted", "fred" };

            List<int> even = new List<int> { list1.Count, list2.Count, list3.Count };

            Assert.False(even.EqualItemCount());
        }

        [Fact]
        public void IsReallyNotEven()
        {
            List<int> list1 = new List<int> { 1, 2 };
            List<int> list2 = new List<int> { 1, 2, 3, 6 };
            List<string> list3 = new List<string> { "john", "ted", "fred" };

            List<int> even = new List<int> { list1.Count, list2.Count, list3.Count };

            Assert.False(even.EqualItemCount());
        }

        [Fact]
        public void IsReallyReallyNotEven()
        {
            List<int> list1 = new List<int> { 1, 2 };
            List<int> list2 = new List<int> { 1, 2, 3, 6, 9, 10, 122, -13 };
            List<string> list3 = new List<string> { "john", "ted", "fred" };
            List<string> list4 = new List<string> { "john", "ted", "fred", "john", "ted", "fred", "john", "ted", "fred", "john", "ted", "fred" };
            List<string> list5 = new List<string> { "john", "ted", "fred", "john", "ted", "fred", "john", "ted", "fred" };

            List<int> even = new List<int> { list1.Count, list2.Count, list3.Count };

            Assert.False(even.EqualItemCount());
        }
    }
}
