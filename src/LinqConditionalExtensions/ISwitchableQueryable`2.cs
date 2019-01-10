namespace System.Linq
{
    public interface ISwitchableQueryable<TSwitch, TSource> : ISwitchableQueryable<TSwitch, TSource, IQueryable<TSource>>
    {

    }
}
