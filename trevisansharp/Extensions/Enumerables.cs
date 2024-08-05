public static class Enumerables
{
    public static IEnumerable<T> Take<T>(this IEnumerable<T> input, int count)
    {
        var iterator = input.GetEnumerator();
        for (int i = 0; i < count && iterator.MoveNext(); i++)
        {
            yield return iterator.Current;
        }
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> input, int count)
    {
        var iterator = input.GetEnumerator();
        for (int i = 0; iterator.MoveNext(); i++)
        {
            if(i < count) continue;

            yield return iterator.Current;
        }
    }

    public static int Count<T>(this IEnumerable<T> input)
    {
        var iterator = input.GetEnumerator();
        int total = 0;
        while (iterator.MoveNext())
        {
            total++;
        }
        return total;
    }
}