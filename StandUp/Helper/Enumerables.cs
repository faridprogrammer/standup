using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StandUp
{
    public delegate TResult Func<TSource, TResult>(TSource item);

    static class Enumerables
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            var list = new LinkedList<TResult>();

            foreach (TSource item in source)
            {
                list.Add(selector(item));
            }

            return list;
        }

        public static Dictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
        {
            var dic = new Dictionary<TKey, TValue>();

            foreach (TSource item in source)
            {
                dic.Add(keySelector(item), valueSelector(item));
            }

            return dic;
        }

        public static T[] ToArray<T>(IEnumerable<T> source)
        {
            var list = new LinkedList<T>();

            foreach (T item in source)
            {
                list.Add(item);
            }

            var result = new T[list.Count];

            list.CopyTo(result);

            return result;
        }
        public static List<T> ToList<T>(IEnumerable<T> source)
        {
            var list = new LinkedList<T>();

            foreach (T item in source)
            {
                list.Add(item);
            }

            var result = new List<T>(list.Count);

            list.CopyTo(result);

            return result;
        }
    }
}
