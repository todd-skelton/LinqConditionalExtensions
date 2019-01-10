using System.Collections.Generic;

namespace System.Linq
{
    public interface ISwitchableEnumerable<TSwitch, TSource> : ISwitchableEnumerable<TSwitch, TSource, IEnumerable<TSource>>
    {
        TSwitch Switch { get; }
    }
}
