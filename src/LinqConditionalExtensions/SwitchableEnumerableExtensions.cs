using System.Collections.Generic;

namespace System.Linq
{
    public static class SwitchableEnumerableExtensions
    {
        public static ISwitchableEnumerable<TSwitch, TSource> Switch<TSwitch, TSource>(this IEnumerable<TSource> source, TSwitch @switch)
            => new SwitchableEnumerable<TSwitch, TSource>(source, @switch);

        public static ISwitchableEnumerable<TSwitch, TSource, TResult> Switch<TSwitch, TSource, TResult>(this IEnumerable<TSource> source, TSwitch @switch)
            => new SwitchableEnumerable<TSwitch, TSource, TResult>(source, @switch);

        public static ISwitchableEnumerable<TSwitch, TSource> Case<TSwitch, TSource>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, expression, match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource, TResult> Case<TSwitch, TSource, TResult>(this ISwitchableEnumerable<TSwitch, TSource, TResult> switchable, TSwitch match, Func<IEnumerable<TSource>, TResult> expression)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource, TResult>(switchable.Source, switchable.Switch, expression, match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> Case<TSwitch, TSource>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSwitch, bool> casePredicate, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, expression, casePredicate(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource, TResult> Case<TSwitch, TSource, TResult>(this ISwitchableEnumerable<TSwitch, TSource, TResult> switchable, Func<TSwitch, bool> casePredicate, Func<IEnumerable<TSource>, TResult> expression)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource, TResult>(switchable.Source, switchable.Switch, expression, casePredicate(switchable.Switch));

        public static IEnumerable<TSource> Default<TSwitch, TSource>(this ISwitchableEnumerable<TSwitch, TSource> switchable)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source;

        public static IEnumerable<TSource> Default<TSwitch, TSource>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : expression.Invoke(switchable.Source);

        public static TResult Default<TSwitch, TSource, TResult>(this ISwitchableEnumerable<TSwitch, TSource, TResult> switchable, Func<IEnumerable<TSource>, TResult> expression)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : expression.Invoke(switchable.Source);

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderBy(keySelector, comparer), match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<TSource, TKey> keySelector)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderBy(keySelector), match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSwitch, bool> casePredicate, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderBy(keySelector, comparer), casePredicate(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSwitch, bool> casePredicate, Func<TSource, TKey> keySelector)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderBy(keySelector), casePredicate(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByDescendingCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderByDescending(keySelector, comparer), match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByDescendingCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<TSource, TKey> keySelector)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderByDescending(keySelector), match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByDescendingCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSwitch, bool> casePredicate, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderByDescending(keySelector, comparer), casePredicate(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> OrderByDescendingCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSwitch, bool> casePredicate, Func<TSource, TKey> keySelector)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.OrderByDescending(keySelector), casePredicate(switchable.Switch));

        public static IEnumerable<TSource> OrderByDefault<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source.OrderBy(keySelector, comparer);

        public static IEnumerable<TSource> OrderByDefault<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSource, TKey> keySelector)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source.OrderBy(keySelector);

        public static IEnumerable<TSource> OrderByDescendingDefault<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source.OrderByDescending(keySelector, comparer);

        public static IEnumerable<TSource> OrderByDescendingDefault<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSource, TKey> keySelector)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source.OrderByDescending(keySelector);

        public static ISwitchableEnumerable<TSwitch, TSource> WhereCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<TSource, int, bool> predicate)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.Where(predicate), match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> WhereCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, TSwitch match, Func<TSource, bool> predicate)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.Where(predicate), match.Equals(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> WhereCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSwitch, bool> casePredicate, Func<TSource, int, bool> predicate)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.Where(predicate), casePredicate(switchable.Switch));

        public static ISwitchableEnumerable<TSwitch, TSource> WhereCase<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSwitch, bool> casePredicate, Func<TSource, bool> predicate)
            => switchable.IsMet ? switchable : new SwitchableEnumerable<TSwitch, TSource>(switchable.Source, switchable.Switch, e => e.Where(predicate), casePredicate(switchable.Switch));

        public static IEnumerable<TSource> WhereDefault<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSource, int, bool> predicate)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source.Where(predicate);

        public static IEnumerable<TSource> WhereDefault<TSwitch, TSource, TKey>(this ISwitchableEnumerable<TSwitch, TSource> switchable, Func<TSource, bool> predicate)
            => switchable.IsMet ? switchable.Expression.Invoke(switchable.Source) : switchable.Source.Where(predicate);
    }
}