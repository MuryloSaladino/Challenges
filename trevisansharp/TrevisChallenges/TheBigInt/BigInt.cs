using System.Text;

public class BigInt
{
    private byte[] bytes;

    
    public BigInt(int size)
    {
        bytes = new byte[size];
    }
    public BigInt(long start)
    {
        bytes = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            bytes[i] = (byte)(start >> (8*i));
        }
    }



    public static BigInt operator +(BigInt a, BigInt b) 
    {
        BigInt result = new BigInt(a > b ? a.bytes.Length : b.bytes.Length);
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
            if(a.bytes[i] > b.bytes[i])
                return true;
        }
        return false;
    }

    public static bool operator <(BigInt a, BigInt b) 
    {
        if(a.bytes.Length != b.bytes.Length)
            return a.bytes.Length < b.bytes.Length;

        for (int i = a.bytes.Length - 1; i > -1; i--)
        {
            if(a.bytes[i] < b.bytes[i])
                return true;
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

            // Remove leading zeroes from the byte array
            while (temp.Count > 0 && temp[temp.Count - 1] == 0)
            {
                temp.RemoveAt(temp.Count - 1);
            }

            result.Insert(0, remainder);
        }

        return result.Length == 0 ? "0" : result.ToString();
    }
}