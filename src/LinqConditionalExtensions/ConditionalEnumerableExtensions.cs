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
    }
}
