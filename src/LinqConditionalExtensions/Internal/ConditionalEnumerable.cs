using System.Collections.Generic;

namespace System.Linq
{
    internal class ConditionalEnumerable<T> : IConditionalEnumerable<T>
    {
        public ConditionalEnumerable(IEnumerable<T> source, Func<IEnumerable<T>, IEnumerable<T>> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IEnumerable<T> Source { get; }

        public Func<IEnumerable<T>, IEnumerable<T>> Expression { get; }

        public bool IsMet { get; }
    }
}
