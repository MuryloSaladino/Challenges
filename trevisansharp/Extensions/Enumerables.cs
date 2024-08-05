public static class Enumerables
{
    public static IEnumerable<T> Take<T>(this IEnumerable<T> input, int count)
    {
        var it = input.GetEnumerator();
        for (int i = 0; i < count && it.MoveNext(); i++)
        {
            yield return it.Current;
        }
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> input, int count)
    {
        var it = input.GetEnumerator();
        for (int i = 0; it.MoveNext(); i++)
        {
            if(i < count) continue;

            yield return it.Current;
        }
    }

    public static int Count<T>(this IEnumerable<T> input)
    {
        var it = input.GetEnumerator();
        int total = 0;
        while (it.MoveNext())
        {
            total++;
        }
        return total;
    }

    public static T[] ToArray<T>(this IEnumerable<T> input)
    {
        T[] array = new T[input.Count()];
        var it = input.GetEnumerator();

        for (int i = 0; i < array.Length && it.MoveNext(); i++)
        {
            array[i] = it.Current;
        }
        return array;
    }


}