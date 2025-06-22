using System.Collections;

namespace Learn_CSharp_Deep_Dot_NET_LINQ;

public sealed class SelectManualEnumerable<TSource, TResult>(
    IEnumerable<TSource> source,
    Func<TSource, TResult> selector
) : IEnumerable<TResult>
{
    public IEnumerator<TResult> GetEnumerator()
    {
        return new Enumerator(source, selector);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private sealed class Enumerator(
        IEnumerable<TSource> source,
        Func<TSource, TResult> selector
    ) : IEnumerator<TResult>
    {
        private IEnumerator<TSource>? enumerator;
        private int state = 1;

        public TResult Current { get; private set; } = default!;
        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            state = -1;
            enumerator?.Dispose();
        }

        public bool MoveNext()
        {
            if (state == 1)
            {
                enumerator = source.GetEnumerator();
                state = 2;
            }

            if (state == 2)
            {
                try
                {
                    if (enumerator.MoveNext())
                    {
                        Current = selector(enumerator.Current);
                        return true;
                    }
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }

            Dispose();
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}