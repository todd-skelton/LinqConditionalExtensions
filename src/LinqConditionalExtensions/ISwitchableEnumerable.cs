namespace System.Linq
{
    public interface ISwitchableEnumerable<TSwitch, TSource, TResult> : IConditionalEnumerable<TSource, TResult>
    {
        TSwitch Switch { get; }
    }
}
