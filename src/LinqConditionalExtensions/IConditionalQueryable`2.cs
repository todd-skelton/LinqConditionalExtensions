namespace System.Linq
{
    public interface IConditionalQueryable<TSource, TResult>
    {
        IQueryable<TSource> Source { get; }
        Func<IQueryable<TSource>, TResult> Expression { get; }
        bool IsMet { get; }
    }
}
