using System.Collections.Generic;

namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> AppendIf<TSource>(this IEnumerable<TSource> source, bool condition, TSource element)
            => condition ? source.Append(element) : source;

        public static IEnumerable<TSource> ConcatIf<TSource>(this IEnumerable<TSource> first, bool condition, IEnumerable<TSource> second)
            => condition ? first.Concat(second) : first;

        public static IEnumerable<TSource> DistinctIf<TSource>(this IEnumerable<TSource> source, bool condition)
            => condition ? source.Distinct() : source;

        public static IEnumerable<TSource> DistinctIf<TSource>(this IEnumerable<TSource> source, bool condition, IEqualityComparer<TSource> comparer)
            => condition ? source.Distinct(comparer) : source;

        public static IEnumerable<TSource> ExceptIf<TSource>(this IEnumerable<TSource> first, bool condition, IEnumerable<TSource> second)
            => condition ? first.Except(second) : first;

        public static IEnumerable<TSource> ExceptIf<TSource>(this IEnumerable<TSource> first, bool condition, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
            => condition ? first.Except(second, comparer) : first;

        public static IEnumerable<TSource> IntersectIf<TSource>(this IEnumerable<TSource> first, bool condition, IEnumerable<TSource> second)
            => condition ? first.Intersect(second) : first;

        public static IEnumerable<TSource> IntersectIf<TSource>(this IEnumerable<TSource> first, bool condition, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
            => condition ? first.Intersect(second, comparer) : first;

        public static IOrderedEnumerable<TSource> OrderByIf<TSource, TKey>(this IEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => condition ? source.OrderBy(keySelector, comparer) : source.OrderBy(e => true);

        public static IOrderedEnumerable<TSource> OrderByIf<TSource, TKey>(this IEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector)
            => condition ? source.OrderBy(keySelector) : source.OrderBy(e => true);

        public static IOrderedEnumerable<TSource> OrderByDescendingIf<TSource, TKey>(this IEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector)
            => condition ? source.OrderByDescending(keySelector) : source.OrderByDescending(e => true);

        public static IOrderedEnumerable<TSource> OrderByDescendingIf<TSource, TKey>(this IEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => condition ? source.OrderByDescending(keySelector, comparer) : source.OrderByDescending(e => true);

        public static IEnumerable<TSource> PrependIf<TSource>(this IEnumerable<TSource> source, bool condition, TSource element)
            => condition ? source.Prepend(element) : source;

        public static IEnumerable<TSource> ReverseIf<TSource>(this IEnumerable<TSource> source, bool condition)
            => condition ? source.Reverse() : source;

        public static IEnumerable<TSource> SkipIf<TSource>(this IEnumerable<TSource> source, bool condition, int count)
            => condition ? source.Skip(count) : source;

        public static IEnumerable<TSource> SkipWhileIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
            => condition ? source.SkipWhile(predicate) : source;

        public static IEnumerable<TSource> SkipWhileIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
            => condition ? source.SkipWhile(predicate) : source;

        public static IEnumerable<TSource> TakeIf<TSource>(this IEnumerable<TSource> source, bool condition, int count)
            => condition ? source.Take(count) : source;

        public static IEnumerable<TSource> TakeWhileIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
            => condition ? source.TakeWhile(predicate) : source;

        public static IEnumerable<TSource> TakeWhileIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
            => condition ? source.TakeWhile(predicate) : source;

        public static IOrderedEnumerable<TSource> ThenByIf<TSource, TKey>(this IOrderedEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector)
            => condition ? source.ThenBy(keySelector) : source;

        public static IOrderedEnumerable<TSource> ThenByIf<TSource, TKey>(this IOrderedEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => condition ? source.ThenBy(keySelector, comparer) : source;

        public static IOrderedEnumerable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => condition ? source.ThenByDescending(keySelector, comparer) : source;

        public static IOrderedEnumerable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedEnumerable<TSource> source, bool condition, Func<TSource, TKey> keySelector)
            => condition ? source.ThenByDescending(keySelector) : source;

        public static IEnumerable<TSource> UnionIf<TSource>(this IEnumerable<TSource> first, bool condition, IEnumerable<TSource> second)
            => condition ? first.Union(second) : first;

        public static IEnumerable<TSource> UnionIf<TSource>(this IEnumerable<TSource> first, bool condition, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
            => condition ? first.Union(second, comparer) : first;

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
            => condition ? source.Where(predicate) : source;

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
            => condition ? source.Where(predicate) : source;
    }
}
