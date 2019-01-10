namespace System.Linq
{
    public interface ISwitchableQueryable<TSwitch, TSource, TResult> : IConditionalQueryable<TSource, TResult>
    {
        TSwitch Switch { get; }
    }
}
