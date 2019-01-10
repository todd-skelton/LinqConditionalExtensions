namespace System.Linq
{
    internal class ConditionalQueryable<TSource, TResult> : IConditionalQueryable<TSource, TResult>
    {
        public ConditionalQueryable(IQueryable<TSource> source, Func<IQueryable<TSource>, TResult> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IQueryable<TSource> Source { get; }

        public Func<IQueryable<TSource>, TResult> Expression { get; }

        public bool IsMet { get; }
    }
}
