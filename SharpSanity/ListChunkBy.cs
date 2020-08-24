using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpSanity.Linq
{
    public static class ListChunkBy
    {
        /// <summary>
        /// Chunks a list into sizes of a specifc type
        /// </summary>
        /// <param name="chunkSize">How big should each chunk be?</param>
        /// <returns></returns>
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            // we get less that zero throw outofrange exception
            if (chunkSize < 0)
                throw new ArgumentOutOfRangeException("chunkSize", "Chunk size must be zero or greater");

            // If we get a zero for the chunk size
            if (chunkSize == 0)
                chunkSize = 1;

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
