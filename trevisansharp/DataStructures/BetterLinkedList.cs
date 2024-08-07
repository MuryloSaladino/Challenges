using System.Collections;

public class BetterLinkedList<T> : ICollection<T>
{
    const int maxSize = 32;

    private Node head = new();

    public bool IsReadOnly => false;
    public int Count { get; private set; } = 0;

    internal class Node
    {
        internal T[] Values { get; set; } = new T[maxSize];
        internal Node Next { get; set; } = null;
        internal int FilledSlots { get; set; } = 0;

        internal bool Remove(T item)
        {
            int index = IndexOf(item);

            if(index > -1)
            {
                FilledSlots--;
                Values[index] = default;

                return true;
            }
            return false;
        }

        internal int IndexOf(T item)
        {
            for (int i = 0; i < FilledSlots; i++)
            {
                if(item.Equals(Values[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public T this[int index]
    {
        get
        {
            var lastNode = head;
            for(int i = 0; i < Count / index; i++)
            {
                lastNode = lastNode.Next;
            }
            return lastNode.Values[index % maxSize];
        }
        set
        {
            var lastNode = head;
            for(int i = 0; i < Count / index; i++)
            {
                lastNode = lastNode.Next;
            }
            lastNode.Values[index % maxSize] = value;
        }
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
            lastList.Next = new Node();
            lastList = lastList.Next;
        }

        lastList.Values[Count % maxSize] = item;

        Count++;
        lastList.FilledSlots++;
    }

    public void Clear()
    {
        Count = 0;
        head = new Node();
    }

    public bool Contains(T item)
    {
        foreach(var element in this) 
        {
            if(item.Equals(element)) return true;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        foreach(var element in this)
        {
            array[arrayIndex++] = element;
        }
    }

    public IEnumerator<T> GetEnumerator() => new Enumerator(head);

    public bool Remove(T item)
    {
        var currentNode = head;
        
        do
        {
            if(currentNode.Remove(item))
            {
                return true;
            }

            if(currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
        }
        while(currentNode.Next != null);
        
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class Enumerator(Node list) : IEnumerator<T>
    {
        private Node currentList = list;
        private Node startNode = list;
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
