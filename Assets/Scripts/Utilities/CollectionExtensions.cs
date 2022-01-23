using System;
using System.Linq;
using System.Collections.Generic;

namespace MatoApp.Utilities
{
    /// <summary>
    /// コレクションの機能拡張クラス
    /// </summary>
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var x in self)
            {
                action(x);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> self, Action<T, int> action)
        {
            foreach ((var x, var i) in self.Select((x, i) => (x, i)))
            {
                action(x, i);
            }
        }

        public static IEnumerable<T> Do<T>(this IEnumerable<T> self, Action<T> action)
        {
            self.ForEach(action);

            return self;
        }
    }
}
