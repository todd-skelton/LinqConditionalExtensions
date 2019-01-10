using System.Collections.Generic;

namespace System.Linq
{
    internal class SwitchableEnumerable<TSwitch, TSource> : ISwitchableEnumerable<TSwitch, TSource>
    {
        public SwitchableEnumerable(IEnumerable<TSource> source, TSwitch @switch)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Switch = @switch;
            Expression = null;
            IsMet = false;
        }

        public SwitchableEnumerable(IEnumerable<TSource> source, TSwitch @switch, Func<IEnumerable<TSource>, IEnumerable<TSource>> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Switch = @switch;
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IEnumerable<TSource> Source { get; }

        public TSwitch Switch { get; }

        public Func<IEnumerable<TSource>, IEnumerable<TSource>> Expression { get; }

        public bool IsMet { get; }
    }
}
