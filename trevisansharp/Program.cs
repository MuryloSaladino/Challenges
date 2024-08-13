using System.Diagnostics;

BigIntList lista = new(40);

Stopwatch sw = new Stopwatch();

sw.Start();
lista.MergeSort();
sw.Stop();

foreach (var item in lista.Numbers)
{   
    Console.WriteLine(item);
}

Console.WriteLine($"\nTempo: {sw}");
