using System.Collections.Generic;

namespace System.Linq
{
    public static class ConditionalEnumerableExtensions
    {
        public static IEnumerable<T> If<T>(this IEnumerable<T> source, bool condition, Func<IEnumerable<T>, IEnumerable<T>> expression)
            => condition ? expression.Invoke(source) : source;

        public static IConditionalEnumerable<TSource> If<TSource>(this IConditionalEnumerable<TSource> conditional, bool condition, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => condition ? new ConditionalEnumerable<TSource>(conditional.Source, e => expression(conditional.Expression(e)), condition) : new ConditionalEnumerable<TSource>(conditional.Source, expression, condition);

        public static IConditionalEnumerable<TSource> IfChain<TSource>(this IEnumerable<TSource> source, bool condition, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => new ConditionalEnumerable<TSource>(source, expression, condition);

        public static IConditionalEnumerable<TSource, TResult> IfChain<TSource, TResult>(this IEnumerable<TSource> source, bool condition, Func<IEnumerable<TSource>, TResult> expression)
            => new ConditionalEnumerable<TSource, TResult>(source, expression, condition);

        public static IConditionalEnumerable<TSource> ElseIf<TSource>(this IConditionalEnumerable<TSource> conditional, bool condition, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => conditional.IsMet ? conditional : new ConditionalEnumerable<TSource>(conditional.Source, expression, condition);

        public static IConditionalEnumerable<TSource, TResult> ElseIf<TSource, TResult>(this IConditionalEnumerable<TSource, TResult> conditional, bool condition, Func<IEnumerable<TSource>, TResult> expression)
            => conditional.IsMet ? conditional : new ConditionalEnumerable<TSource, TResult>(conditional.Source, expression, condition);

        public static IEnumerable<TSource> Else<TSource>(this IConditionalEnumerable<TSource> conditional)
            => conditional.IsMet ? conditional.Expression.Invoke(conditional.Source) : conditional.Source;

        public static IEnumerable<TSource> Else<TSource>(this IConditionalEnumerable<TSource> conditional, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => conditional.IsMet ? conditional.Expression.Invoke(conditional.Source) : expression.Invoke(conditional.Source);

        public static TResult Else<TSource, TResult>(this IConditionalEnumerable<TSource, TResult> conditional, Func<IEnumerable<TSource>, TResult> expression)
            => conditional.IsMet ? conditional.Expression.Invoke(conditional.Source) : expression.Invoke(conditional.Source);

        public static ISwitchableEnumerable<TSwitch, TSource> Switch<TSwitch, TSource>(this IEnumerable<TSource> source, TSwitch @switch)
            => new SwitchableEnumerable<TSwitch, TSource>(source, @switch);

        public static ISwitchableEnumerable<TSwitch, TSource, TResult> Switch<TSwitch, TSource, TResult>(this IEnumerable<TSource> source, TSwitch @switch)
            => new SwitchableEnumerable<TSwitch, TSource, TResult>(source, @switch);

        public static ISwitchableEnumerable<TSwitch, TSource> Case<TSwitch, TSource>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, expression, match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource, TResult> Case<TSwitch, TSource, TResult>(this ISwitchableEnumerable<TSwitch, TSource, TResult> switchable, TSwitch match, Func<IEnumerable<TSource>, TResult> expression)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource, TResult>(switchable.Source, switchable.Switch, expression, match.Equals(switchable.Switch));

        public static IEnumerable<TSource> Default<TSwitch, TSource>(this ISwitchableEnumerable<TSwitch, TSource> switchable)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source;

        public static IEnumerable<TSource> Default<TSwitch, TSource>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : expression.Invoke(switchable.Source);

        public static TResult Default<TSwitch, TSource, TResult>(this ISwitchableEnumerable<TSwitch, TSource, TResult> switchable, Func<IEnumerable<TSource>, TResult> expression)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : expression.Invoke(switchable.Source);

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
