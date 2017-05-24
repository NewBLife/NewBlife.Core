using System.Collections.Generic;

namespace NewBlife.Core.Extensions
{
    /// <summary>
    /// Collection extension method HasValue
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// Determines whether this list instance has value.
        /// </summary>
        /// <typeparam name="T">list type</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>
        ///   <c>true</c> if the list has value; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasValue<T>(this List<T> list)
        {
            return !(list == null || list.Count == 0);
        }

        /// <summary>
        /// Determines whether this Dictionary instance has value.
        /// </summary>
        /// <typeparam name="Tkey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dic">The Dictionary.</param>
        /// <returns>
        ///   <c>true</c> if the Dictionary has value; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasValue<Tkey, TValue>(this Dictionary<Tkey, TValue> dic)
        {
            return !(dic == null || dic.Count == 0);
        }

        /// <summary>
        /// Determines whether this instance has value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">The arr.</param>
        /// <returns>
        ///   <c>true</c> if the specified arr has value; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasValue<T>(this T[] arr)
        {
            return !(arr == null || arr.Length == 0);
        }
    }
}
