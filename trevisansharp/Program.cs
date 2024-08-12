BigIntList lista = new(12);

foreach (var item in lista.Numbers)
{   
    Console.WriteLine(item);
}

var listaA = lista.Numbers[..6];
var listaB = lista.Numbers[6..];
Console.WriteLine();


foreach (var item in listaA)
{   
    Console.WriteLine(item);
}
Console.WriteLine();
foreach (var item in listaB)
{   
    Console.WriteLine(item);
}