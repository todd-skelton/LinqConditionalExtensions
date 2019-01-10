namespace System.Linq
{
    internal class ConditionalQueryable<TSource, TResult> : IConditionalQueryable<TSource, TResult>
    {
        public ConditionalQueryable(IQueryable<TSource> source, Func<IQueryable<TSource>, IQueryable<TResult>> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IQueryable<TSource> Source { get; }

        public Func<IQueryable<TSource>, IQueryable<TResult>> Expression { get; }

        public bool IsMet { get; }
    }
}
