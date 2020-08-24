using System;
using System.Collections.Generic;
using Xunit;
using SharpSanity.Linq;

namespace SharpSanity.Tests
{
    public class ChunkUnitTests
    {
        [Fact]
        public void EvensChunk()
        {
            List<int> evenList = new List<int> { 1, 2, 3, 4 };
            var evenChunkList = evenList.ChunkBy(2);
            Assert.Equal(2, evenChunkList.Count);
        }

        [Fact]
        public void OddsChunk()
        {
            List<int> evenList = new List<int> { 1, 2, 3, 4, 5 };
            var evenChunkList = evenList.ChunkBy(2);
            Assert.Equal(3, evenChunkList.Count);
        }

        [Fact]
        public void CorrectsZeroChunkSizeToOne()
        {
            List<int> evenList = new List<int> { 1, 2, 3, 4, 5 };
            var evenChunkList = evenList.ChunkBy(0);
            Assert.Equal(5, evenChunkList.Count);
        }

        [Fact]
        public void ErrorsOnNegativeChunkSize()
        {
            try
            {
                List<int> evenList = new List<int> { 1, 2, 3, 4, 5 };
                var evenChunkList = evenList.ChunkBy(-1);
                Assert.True(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }
    }
}
