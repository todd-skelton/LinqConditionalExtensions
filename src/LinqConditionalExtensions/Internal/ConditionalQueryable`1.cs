namespace System.Linq
{
    internal class ConditionalQueryable<T> : IConditionalQueryable<T>
    {
        public ConditionalQueryable(IQueryable<T> source, Func<IQueryable<T>, IQueryable<T>> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IQueryable<T> Source { get; }

        public Func<IQueryable<T>, IQueryable<T>> Expression { get; }

        public bool IsMet { get; }
    }
}
