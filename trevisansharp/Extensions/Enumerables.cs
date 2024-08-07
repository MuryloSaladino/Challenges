public static class Enumerables
{
    public static IEnumerable<T> CustomTake<T>(this IEnumerable<T> input, int count)
    {
        var it = input.GetEnumerator();
        for (int i = 0; i < count && it.MoveNext(); i++)
        {
            yield return it.Current;
        }
    }

    public static IEnumerable<T> CustomSkip<T>(this IEnumerable<T> input, int count)
    {
        var it = input.GetEnumerator();
        for (int i = 0; it.MoveNext(); i++)
        {
            if(i < count) continue;

            yield return it.Current;
        }
    }

    public static int CustomCount<T>(this IEnumerable<T> input)
    {
        var it = input.GetEnumerator();
        int total = 0;
        while (it.MoveNext())
        {
            total++;
        }
        return total;
    }

    public static T[] CustomToArray<T>(this IEnumerable<T> input)
    {
        T[] array = new T[input.Count()];
        var it = input.GetEnumerator();

        for (int i = 0; i < array.Length && it.MoveNext(); i++)
        {
            array[i] = it.Current;
        }
        return array;
    }

    public static IEnumerable<T> CustomAppend<T>(this IEnumerable<T> input, T item)
    {
        var it = input.GetEnumerator();
        
        while(it.MoveNext())
        {
            yield return it.Current;
        }
        yield return item;
    }

    public static IEnumerable<T> CustomPrepend<T>(this IEnumerable<T> input, T item)
    {
        var it = input.GetEnumerator();
        yield return item;
        
        while(it.MoveNext())
        {
            yield return it.Current;
        }
    }

    public static bool CustomEmpty<T>(this IEnumerable<T> input) => input.GetEnumerator().MoveNext();

    public static T CustomFirstOrDefault<T>(this IEnumerable<T> input) 
    {
        var it = input.GetEnumerator();
        return it.MoveNext() ? it.Current : default;
    }

    public static IEnumerable<(T, R)> CustomZip<T, R>(this IEnumerable<T> input, IEnumerable<R> second)
    {
        var itFirst = input.GetEnumerator();
        var itSecond = second.GetEnumerator();

        while(itFirst.MoveNext() && itSecond.MoveNext())
        {
            yield return (itFirst.Current, itSecond.Current);
        }
    } 

    public static IEnumerable<T[]> CustomChunk<T>(this IEnumerable<T> input, int size)
    {
        var it = input.GetEnumerator();
        var currentArray = new T[size];

        for(int i = 0; it.MoveNext(); i++)
        {
            currentArray[i] = it.Current;

            if(i == size) 
            {
                yield return currentArray;
                i = 0;
                currentArray = new T[size];
            }
        }
    }

    public static IEnumerable<T> CustomFilter<T>(this IEnumerable<T> input, Func<T, bool> callback)
    {
        var it = input.GetEnumerator();

        while(it.MoveNext())
        {
            if(callback(it.Current))
            {
                yield return it.Current;
            }
        }
    }

    public static IEnumerable<R> CustomSelect<T, R>(this IEnumerable<T> input, Func<T, R> callback)
    {
        var it = input.GetEnumerator();

        while(it.MoveNext())
        {
            yield return callback(it.Current);
        }
    }
    
    public static T CustomFind<T>(this IEnumerable<T> input, Func<T, bool> callback)
    {
        var it = input.GetEnumerator();

        while(it.MoveNext())
        {
            if(callback(it.Current))
            {
                return it.Current;
            }
        }
        throw new Exception("Element not found");
    }

    public static R CustomReduce<T, R>(this IEnumerable<T> input, Func<R, T, R> callback, R initialValue)
    {
        var it = input.GetEnumerator();

        while(it.MoveNext())
        {
            initialValue = callback(initialValue, it.Current);
        }
        return initialValue;
    }

    public static IEnumerable<T> CustomTakeWhile<T>(this IEnumerable<T> input, Func<T, bool> predicate)
    {
        foreach(T element in input)
        {
            if(!predicate(element)) break;
            yield return element;
        }
    }

    public static IEnumerable<T> CustomSkipWhile<T>(this IEnumerable<T> input, Func<T, bool> predicate)
    {
        bool skiping = true;

        foreach(T element in input)
        {
            if(skiping) skiping = predicate(element);
            if(!skiping) yield return element;
        }
    }

    public static T CustomMaxBy<T>(this IEnumerable<T> input, Func<T, double> selector)
    {
        T result = input.FirstOrDefault();
        double resultValue = selector(result);

        foreach(T element in input) 
        {
            if(resultValue < selector(element))
            {
                result = element;
                resultValue = selector(result);
            }
        }
        return result;
    }

    public static bool Any<T>(this IEnumerable<T> input, Func<T, bool> verifier)
    {
        foreach(T element in input)
        {
            if(verifier(element)) return true;
        }
        return false;
    }
}