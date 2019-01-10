namespace System.Linq
{
    internal class SwitchableQueryable<TSwitch, TSource, TResult> : ISwitchableQueryable<TSwitch, TSource, TResult>
    {
        public SwitchableQueryable(IQueryable<TSource> source, TSwitch @switch)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Switch = @switch;
            Expression = null;
            IsMet = false;
        }

        public SwitchableQueryable(IQueryable<TSource> source, TSwitch @switch, Func<IQueryable<TSource>, TResult> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Switch = @switch;
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IQueryable<TSource> Source { get; }

        public TSwitch Switch { get; }

        public Func<IQueryable<TSource>, TResult> Expression { get; }

        public bool IsMet { get; }
    }
}
