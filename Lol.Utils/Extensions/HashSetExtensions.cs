using System.Collections.Generic;
using System.Linq;

namespace Lol.Utils.Extensions
{
    /// <summary>
    /// a
    /// </summary>
    public static class HashSetExtensions
    {
        /// <summary>
        /// Add a collection of items to a hash set.
        /// </summary>
        /// <typeparam name="T">Type of items to add.</typeparam>
        /// <param name="hashSet">HashSet to which items have to be added.</param>
        /// <param name="itemsToAdd">The collection of items which have to be added to the hash set.</param>
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> itemsToAdd)
        {
            itemsToAdd.ForEach(item => hashSet.Add(item));
        }
    }
}
