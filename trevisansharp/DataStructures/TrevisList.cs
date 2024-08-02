using System.Collections;

public class TrevisList<T> : ICollection<T>
{
    const int maxSize = 32;

    private Node<T> head = new Node<T>();

    public bool IsReadOnly => false;
    public int Count { get; private set; } = 0;

    internal class Node<T>
    {
        internal T[] Values { get; set; } = new T[maxSize];
        internal Node<T> Next { get; set; } = null;
        internal int FilledSlots { get; set; } = 0;
    }

    public void Add(T item)
    {
        var lastList = head;

        while(lastList.Next != null)
        {
            lastList = lastList.Next;
        }

        if(lastList.FilledSlots == maxSize)
        {
            lastList.Next = new Node<T>();
            lastList = lastList.Next;
        }

        lastList.Values[Count % maxSize] = item;

        Count++;
        lastList.FilledSlots++;
    }

    public void Clear()
    {
        Count = 0;
        head = new Node<T>();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(head);

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class Enumerator(Node<T> list) : IEnumerator<T>
    {
        private Node<T> currentList = list;
        private Node<T> startNode = list;
        private int currentIndex = -1;

        public T Current => currentList.Values[currentIndex] ?? throw new IndexOutOfRangeException();
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if(currentIndex == maxSize - 1 && currentList.Next != null)
            {
                currentIndex = 0;
                currentList = currentList.Next;
                return true;
            }

            if(currentList.FilledSlots > currentIndex + 1)
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public void Dispose() { }

        public void Reset()
        {
            currentList = startNode;
            currentIndex = -1;
        }
    }
}
