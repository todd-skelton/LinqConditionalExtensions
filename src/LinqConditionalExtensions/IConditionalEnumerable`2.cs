using System.Collections.Generic;

namespace System.Linq
{
    public interface IConditionalEnumerable<TSource, TResult>
    {
        IEnumerable<TSource> Source { get; }
        Func<IEnumerable<TSource>, TResult> Expression { get; }
        bool IsMet { get; }
    }
}
