using System;
using System.Collections.Generic;

namespace MyShop.Shared
{
    public static class GeneralExtentions
    {
        public static Boolean IsEmpty(this Guid target)
        {
            return target == Guid.Empty;
        }

        public static String FormatIt(this String target, params Object[] args)
        {
            return String.Format(target, args);
        }

        public static Boolean ForEach<T>(this IEnumerable<T> target, Predicate<T> expression)
        {
            var result = true;

            foreach(var value in target)
            {
                if(!expression(value))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static Boolean For<T>(this IList<T> target, Func<T, int, bool> expression)
        {
            var result = true;

            for(int i = 0; i < target.Count; i++)
            {
                var value = target[i];
                if(!expression(value, i))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static T AtIndex<T>(this IEnumerable<T> target, int index)
        {
            var enumerator = target.GetEnumerator();

            for(int i = -1; i < index; i++)
            {
                if(!enumerator.MoveNext())
                {
                    throw new ArgumentOutOfRangeException("index");
                }
            }

            return enumerator.Current;
        }
    }
}
