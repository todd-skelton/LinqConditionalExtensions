using System.Collections.Generic;

namespace System.Linq
{
    public interface IConditionalEnumerable<TSource> : IConditionalEnumerable<TSource, IEnumerable<TSource>>
    {

    }
}
