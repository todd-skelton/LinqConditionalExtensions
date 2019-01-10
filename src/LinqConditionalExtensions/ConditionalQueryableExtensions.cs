namespace System.Linq
{
    public static class ConditionalQueryableExtensions
    {
        public static IQueryable<T> If<T>(this IQueryable<T> source, bool condition, Func<IQueryable<T>, IQueryable<T>> expression)
            => condition ? expression.Invoke(source) : source;

        public static IConditionalQueryable<TSource> If<TSource>(this IConditionalQueryable<TSource> conditional, bool condition, Func<IQueryable<TSource>, IQueryable<TSource>> expression)
            => condition ? new ConditionalQueryable<TSource>(conditional.Source, e => expression(conditional.Expression(e)), condition) : new ConditionalQueryable<TSource>(conditional.Source, expression, condition);

        public static IConditionalQueryable<TSource> IfChain<TSource>(this IQueryable<TSource> source, bool condition, Func<IQueryable<TSource>, IQueryable<TSource>> expression)
            => new ConditionalQueryable<TSource>(source, expression, condition);

        public static IConditionalQueryable<TSource, TResult> IfChain<TSource, TResult>(this IQueryable<TSource> source, bool condition, Func<IQueryable<TSource>, TResult> expression)
            => new ConditionalQueryable<TSource, TResult>(source, expression, condition);

        public static IConditionalQueryable<TSource> ElseIf<TSource>(this IConditionalQueryable<TSource> conditional, bool condition, Func<IQueryable<TSource>, IQueryable<TSource>> expression)
            => conditional.IsMet ? conditional : new ConditionalQueryable<TSource>(conditional.Source, expression, condition);

        public static IConditionalQueryable<TSource, TResult> ElseIf<TSource, TResult>(this IConditionalQueryable<TSource, TResult> conditional, bool condition, Func<IQueryable<TSource>, TResult> expression)
            => conditional.IsMet ? conditional : new ConditionalQueryable<TSource, TResult>(conditional.Source, expression, condition);

        public static IQueryable<TSource> Else<TSource>(this IConditionalQueryable<TSource> conditional)
            => conditional.IsMet ? conditional.Expression.Invoke(conditional.Source) : conditional.Source;

        public static IQueryable<TSource> Else<TSource>(this IConditionalQueryable<TSource> conditional, Func<IQueryable<TSource>, IQueryable<TSource>> expression)
            => conditional.IsMet ? conditional.Expression.Invoke(conditional.Source) : expression.Invoke(conditional.Source);

        public static TResult Else<TSource, TResult>(this IConditionalQueryable<TSource, TResult> conditional, Func<IQueryable<TSource>, TResult> expression)
            => conditional.IsMet ? conditional.Expression.Invoke(conditional.Source) : expression.Invoke(conditional.Source);
    }
}
