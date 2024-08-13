BigIntList lista = new(12);

foreach (var item in lista.Numbers)
{   
    Console.WriteLine(item);
}

lista.MergeSort();
Console.WriteLine();

foreach (var item in lista.Numbers)
{   
    Console.WriteLine(item);
}

