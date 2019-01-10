using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class ConditionalQueryableExtensions
    {
        public static IQueryable<T> If<T>(this IQueryable<T> source, bool condition, Func<IQueryable<T>, IQueryable<T>> expression)
            => condition ? expression.Invoke(source) : source;

        public static IConditionalQueryable<TSource, TResult> IfChain<TSource, TResult>(this IQueryable<TSource> source, bool condition, Func<IQueryable<TSource>, IQueryable<TResult>> expression)
            => new ConditionalQueryable<TSource, TResult>(source, expression, condition);

        public static IConditionalQueryable<TSource, TResult> ElseIf<TSource, TResult>(this IConditionalQueryable<TSource, TResult> conditional, bool condition, Func<IQueryable<TSource>, IQueryable<TResult>> expression)
            => conditional.IsMet ? conditional : new ConditionalQueryable<TSource, TResult>(conditional.Source, expression, condition);

        public static IQueryable<TResult> Else<TSource, TResult>(this IConditionalQueryable<TSource, TResult> conditional, Func<IQueryable<TSource>, IQueryable<TResult>> expression)
            => conditional.IsMet ? conditional.Expression.Invoke(conditional.Source) : expression.Invoke(conditional.Source);

        public static ISwitchableQueryable<TSwitch, TSource, TResult> Switch<TSwitch, TSource, TResult>(this IQueryable<TSource> source, TSwitch @switch)
            => new SwitchableQueryable<TSwitch, TSource, TResult>(source, @switch);

        public static ISwitchableQueryable<TSwitch, TSource, TResult> Case<TSwitch, TSource, TResult>(this ISwitchableQueryable<TSwitch, TSource, TResult> switchable, TSwitch match, Func<IQueryable<TSource>, IQueryable<TResult>> expression)
            => switchable.IsMet ? switchable : new SwitchableQueryable<TSwitch, TSource, TResult>(switchable.Source, switchable.Switch, expression, match.Equals(switchable.Switch));

        public static IQueryable<TResult> Default<TSwitch, TSource, TResult>(this ISwitchableQueryable<TSwitch, TSource, TResult> switchable, Func<IQueryable<TSource>, IQueryable<TResult>> expression)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : expression.Invoke(switchable.Source);

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
