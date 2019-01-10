namespace System.Linq
{
    internal class SwitchableQueryable<TSwitch, TSource> : ISwitchableQueryable<TSwitch, TSource>
    {
        public SwitchableQueryable(IQueryable<TSource> source, TSwitch @switch)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Switch = @switch;
            Expression = null;
            IsMet = false;
        }

        public SwitchableQueryable(IQueryable<TSource> source, TSwitch @switch, Func<IQueryable<TSource>, IQueryable<TSource>> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Switch = @switch;
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IQueryable<TSource> Source { get; }

        public TSwitch Switch { get; }

        public Func<IQueryable<TSource>, IQueryable<TSource>> Expression { get; }

        public bool IsMet { get; }
    }
}
