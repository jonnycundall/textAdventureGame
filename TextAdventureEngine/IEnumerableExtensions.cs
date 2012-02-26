using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace TextAdventureEngine
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<Pair<T,T>> AdjacentPairs<T>(this IEnumerable<T> source) 
        {
            IEnumerator<T> e = source.GetEnumerator(); 
            e.MoveNext();
            T current = e.Current;
            while (e.MoveNext())
            {
                T next = e.Current;
                yield return new Pair<T, T>(current, next);
                current = next;
            }
        }

        public static IEnumerable<T> Substitute<T>(this IEnumerable<T> source, T oldItem, T substitute)
        {
            if(!source.Contains(oldItem))
                throw new InvalidOperationException();

            var start = source.TakeWhile(item => !item.Equals(oldItem));
            var mid = new[]{substitute};
            var end = source.Skip(start.Count() + 1);
            return start.Concat(mid).Concat(end);
        }

        public static IEnumerable<T> Substitute<T>(this IEnumerable<T> source, Pair<T,T> oldItems, T substitute)
        {
            T first = default(T);
            int count = 0;
            foreach (T item in source)
            {
                var second = item;
                if (first != null 
                    && first.Equals(oldItems.First) 
                    && second.Equals(oldItems.Second))
                {
                    var start = source.Take(count -1);
                    var mid = new[] { substitute };
                    var end = source.Skip(count + 1);
                    return start.Concat(mid).Concat(end);
                }
                first = second;
                count++;
            }

            throw new InvalidOperationException();
        }
    }
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
}
