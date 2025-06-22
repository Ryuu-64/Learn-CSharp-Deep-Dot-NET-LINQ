namespace Learn_CSharp_Deep_Dot_NET_LINQ;

public static class MyLinq
{
    public static IEnumerable<TResult> SelectCompiler<TSource, TResult>(
        IEnumerable<TSource> source, Func<TSource, TResult> selector
    )
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
        return Impl(source, selector);

        static IEnumerable<TResult> Impl(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
    }

    public static IEnumerable<TResult> SelectManual<TSource, TResult>(
        IEnumerable<TSource> source, Func<TSource, TResult> selector
    )
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);

        return new SelectManualEnumerable<TSource, TResult>(source, selector);
    }
}