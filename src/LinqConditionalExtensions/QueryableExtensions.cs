using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> ConcatIf<TSource>(this IQueryable<TSource> first, bool condition, IQueryable<TSource> second)
            => condition ? first.Concat(second) : first;

        public static IQueryable<TSource> DistinctIf<TSource>(this IQueryable<TSource> source, bool condition)
            => condition ? source.Distinct() : source;

        public static IQueryable<TSource> DistinctIf<TSource>(this IQueryable<TSource> source, bool condition, IEqualityComparer<TSource> comparer)
            => condition ? source.Distinct(comparer) : source;

        public static IQueryable<TSource> ExceptIf<TSource>(this IQueryable<TSource> first, bool condition, IQueryable<TSource> second)
            => condition ? first.Except(second) : first;

        public static IQueryable<TSource> ExceptIf<TSource>(this IQueryable<TSource> first, bool condition, IQueryable<TSource> second, IEqualityComparer<TSource> comparer)
            => condition ? first.Except(second, comparer) : first;

        public static IQueryable<TSource> IntersectIf<TSource>(this IQueryable<TSource> first, bool condition, IQueryable<TSource> second)
            => condition ? first.Intersect(second) : first;

        public static IQueryable<TSource> IntersectIf<TSource>(this IQueryable<TSource> first, bool condition, IQueryable<TSource> second, IEqualityComparer<TSource> comparer)
            => condition ? first.Intersect(second, comparer) : first;

        public static IOrderedQueryable<TSource> OrderByIf<TSource, TKey>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
            => condition ? source.OrderBy(keySelector, comparer) : source.OrderBy(e => true);

        public static IOrderedQueryable<TSource> OrderByIf<TSource, TKey>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector)
            => condition ? source.OrderBy(keySelector) : source.OrderBy(e => true);

        public static IOrderedQueryable<TSource> OrderByDescendingIf<TSource, TKey>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector)
            => condition ? source.OrderByDescending(keySelector) : source.OrderByDescending(e => true);

        public static IOrderedQueryable<TSource> OrderByDescendingIf<TSource, TKey>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
            => condition ? source.OrderByDescending(keySelector, comparer) : source.OrderByDescending(e => true);

        public static IQueryable<TSource> ReverseIf<TSource>(this IQueryable<TSource> source, bool condition)
            => condition ? source.Reverse() : source;

        public static IQueryable<TSource> SkipIf<TSource>(this IQueryable<TSource> source, bool condition, int count)
            => condition ? source.Skip(count) : source;

        public static IQueryable<TSource> SkipWhileIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
            => condition ? source.SkipWhile(predicate) : source;

        public static IQueryable<TSource> SkipWhileIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
            => condition ? source.SkipWhile(predicate) : source;

        public static IQueryable<TSource> TakeIf<TSource>(this IQueryable<TSource> source, bool condition, int count)
            => condition ? source.Take(count) : source;

        public static IQueryable<TSource> TakeWhileIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
            => condition ? source.TakeWhile(predicate) : source;

        public static IQueryable<TSource> TakeWhileIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
            => condition ? source.TakeWhile(predicate) : source;

        public static IOrderedQueryable<TSource> ThenByIf<TSource, TKey>(this IOrderedQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector)
            => condition ? source.ThenBy(keySelector) : source;

        public static IOrderedQueryable<TSource> ThenByIf<TSource, TKey>(this IOrderedQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
            => condition ? source.ThenBy(keySelector, comparer) : source;

        public static IOrderedQueryable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
            => condition ? source.ThenByDescending(keySelector, comparer) : source;

        public static IOrderedQueryable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedQueryable<TSource> source, bool condition, Expression<Func<TSource, TKey>> keySelector)
            => condition ? source.ThenByDescending(keySelector) : source;

        public static IQueryable<TSource> UnionIf<TSource>(this IQueryable<TSource> first, bool condition, IQueryable<TSource> second)
            => condition ? first.Union(second) : first;

        public static IQueryable<TSource> UnionIf<TSource>(this IQueryable<TSource> first, bool condition, IQueryable<TSource> second, IEqualityComparer<TSource> comparer)
            => condition ? first.Union(second, comparer) : first;

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
            => condition ? source.Where(predicate) : source;

        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
            => condition ? source.Where(predicate) : source;
    }
}
