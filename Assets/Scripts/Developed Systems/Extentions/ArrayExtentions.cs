using System;
using System.Linq;
using System.Collections.Generic;


namespace Developed.Extentions
{
    /// <summary>
    /// Various functions for arrays and dictionaries
    /// </summary>
    public static class ArrayExtentions
    {
        /// <summary>
        /// Remove elements after specified key
        /// </summary>
        public static void RemoveAfter<T, Z>(this IDictionary<T, Z> dictionary, T key)
        {
            bool after = false;
            var keys = dictionary.Keys.ToArray();
            int i = 0;

            while (i < dictionary.Count)
            {
                var currentKey = keys[i];

                if (after)
                {
                    dictionary.Remove(currentKey);
                    continue;
                }

                if (currentKey.Equals(key))
                    after = true;

                i++;
            }
        }

        /// <summary>
        /// Remove elements after specified item
        /// </summary>
        public static void RemoveAfter<T>(this IList<T> list, T item)
        {
            bool after = false;
            int i = 0;

            while (i < list.Count)
            {
                var currentItem = list[i];

                if (after)
                {
                    list.Remove(currentItem);
                    continue;
                }

                if (currentItem.Equals(item))
                    after = true;

                i++;
            }
        }

        /// <summary>
        /// Remove elements before specified item
        /// </summary>
        public static void RemoveBefore<T>(this IList<T> list, T item)
        {
            int i = 0;

            while (i < list.Count)
            {
                var currentItem = list[i];
                i++;

                if (currentItem.Equals(item))
                    break;

                list.Remove(currentItem);
            }
        }


        /// <summary>
        /// Get string that contains all items of array
        /// </summary>
        /// <param name="array">Provided array</param>
        /// <returns>Formatted string of array content</returns>
        public static string AllContent<T>(this IEnumerable<T> array)
        {
            string s = string.Format("{0} items: ", array.Count());
            s += string.Join(", ", array);
            return s;
        }
    }
}