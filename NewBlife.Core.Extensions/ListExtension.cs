using System.Collections.Generic;
using System.Linq;

namespace NewBlife.Core.Extensions
{
    public static class ListExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }

        public static bool IsItemExists<T>(this IEnumerable<T> list, T item)
        {
            if (list.IsNullOrEmpty())
            {
                return false;
            }

            return list.Contains(item);
        }
    }
}
