using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Text;

public class BigInt
{
    private byte[] bytes;

    public BigInt(byte[] bytes)
    {
        this.bytes = bytes;
    }
    public BigInt(int input)
    {
        bytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            bytes[i] = (byte)(input >> (8*i));
        }
    }
    public BigInt(long input)
    {
        bytes = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            bytes[i] = (byte)(input >> (8*i));
        }
    }


    public static BigInt operator +(BigInt a, BigInt b) 
    {
        BigInt result = new(new byte[a > b ? a.bytes.Length : b.bytes.Length]);
        bool leftover = false;

        for (int i = 0; i < result.bytes.Length; i++)
        {
            var sum = a.bytes[i] + b.bytes[i];
            if(leftover) sum++;
            
            if(sum > 255) 
            {
                leftover = true;
                result.bytes[i] = (byte)(sum - 256);
                continue;
            }
            result.bytes[i] = (byte)sum;
            leftover = false;
        }
        return result;
    }


    public static bool operator ==(BigInt a, BigInt b) 
    {
        if(a.bytes.Length != b.bytes.Length)
            return false;

        for (int i = 0; i < a.bytes.Length; i++)
        {
            if(a.bytes[i] != b.bytes[i])
                return false;
        }
        return true;
    }

    public static bool operator !=(BigInt a, BigInt b) 
        => !(a == b);

    public static bool operator >(BigInt a, BigInt b) 
    {
        if(a.bytes.Length != b.bytes.Length)
            return a.bytes.Length > b.bytes.Length;

        for (int i = a.bytes.Length - 1; i > -1; i--)
        {
            if(a.bytes[i] != b.bytes[i])
                return a.bytes[i] < b.bytes[i];
        }
        return false;
    }

    public static bool operator <(BigInt a, BigInt b) 
    {
        if(a.bytes.Length != b.bytes.Length)
            return a.bytes.Length < b.bytes.Length;

        for (int i = a.bytes.Length - 1; i > -1; i--)
        {
            if(a.bytes[i] != b.bytes[i])
                return a.bytes[i] < b.bytes[i];
        }
        return false;
    }

    public override string ToString()
    {
        if (bytes == null || bytes.Length == 0) return "0";

        List<byte> temp = new List<byte>(bytes); // Make a copy of the byte array
        StringBuilder result = new StringBuilder();

        while (temp.Count > 0)
        {
            int remainder = 0;
            for (int i = temp.Count - 1; i >= 0; i--)
            {
                int current = (remainder << 8) + temp[i];
                temp[i] = (byte)(current / 10);
                remainder = current % 10;
            }
            while (temp.Count > 0 && temp[temp.Count - 1] == 0)
            {
                temp.RemoveAt(temp.Count - 1);
            }
            result.Insert(0, remainder);
        }

        return result.Length == 0 ? "0" : result.ToString();
    }

    public override bool Equals(object obj) 
        => obj is BigInt bi && bi == this;

    public override int GetHashCode()
        => bytes.Sum(b => b);
}

public class BigIntList
{
    public List<BigInt> Numbers { get; set; } = [];

    public BigIntList(int size) 
    {
        Random rd = new(DateTime.Now.Microsecond);
        for (int i = 0; i < size; i++)
        {
            Numbers.Add(new BigInt(rd.NextInt64()));
        }
    }

    public void MergeSort() 
    {
        int len = Numbers.Count / 4;
        List<BigInt>[] parts = new List<BigInt>[4];

        Parallel.For(0, 4, (index) => {
            parts[index] = Merge(Numbers[(index*len)..(Numbers.Count - index * len)]);
        });


        Numbers = Merge(Merge(parts[0], parts[1]), Merge(parts[2], parts[3]));
    }

    private List<BigInt> Merge(List<BigInt> list)
    {
        int length = list.Count;
        if(length == 1) return list;

        int midPoint = length / 2;
        
        var leftHalf = Merge(list[..midPoint]);
        var rightHalf = Merge(list[midPoint..]);

        return Merge(leftHalf, rightHalf);
    }
    private List<BigInt> Merge(List<BigInt> left, List<BigInt> right)
    {
        List<BigInt> result = [];
        int l = 0;
        int r = 0;

        while(l < left.Count && r < right.Count)
        {
            if(left[l] < right[r])
            {
                result.Add(left[l++]);
                continue;
            }
            result.Add(right[r++]);
        }
        result.AddRange(left[l..]);
        result.AddRange(right[r..]);

        return result;
    }
}
