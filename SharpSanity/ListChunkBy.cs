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
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
