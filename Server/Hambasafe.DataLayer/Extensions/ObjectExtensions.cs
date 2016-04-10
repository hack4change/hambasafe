using System;
using System.Collections.Generic;

namespace Hambasafe.DataLayer.Extensions
{
    public static class ObjectExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T item)
        {
            if (item.Equals(default(T)))
            {
                yield break;
            }

            yield return item;
        }
    }
}
