using System.Collections.Generic;

namespace System.Linq
{
    internal class ConditionalEnumerable<TSource, TResult> : IConditionalEnumerable<TSource, TResult>
    {
        public ConditionalEnumerable(IEnumerable<TSource> source, Func<IEnumerable<TSource>, TResult> expression, bool isMet)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            IsMet = isMet;
        }

        public IEnumerable<TSource> Source { get; }

        public Func<IEnumerable<TSource>, TResult> Expression { get; }

        public bool IsMet { get; }
    }
}
