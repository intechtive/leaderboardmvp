using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaderboard.Utilities
{
    public static class Helpers
    {
        public static void ThrowIfNull(this object instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }
        }

        public static void ThrowIfNullOrEmpty(this string instance)
        {
            if (string.IsNullOrEmpty(instance))
            {
                throw new ArgumentNullException(nameof(instance));
            }
        }
        public static IEnumerable<IEnumerable<T>> Combination<T>(this IEnumerable<T> values, int order = 2)
        {
            int skipIndex = 0;
            foreach (var item in values)
            {
                if (order == 1)
                {
                    yield return new[] { item };
                }
                else
                {
                    foreach (var result in values.Skip(skipIndex + 1).Combination(order - 1))
                    {
                        yield return new[] { item }.Concat(result);
                    }
                }

                skipIndex++;
            }
        }
    }
}
