List<int> mylist = [1,2,3,4,5,6];

var test = mylist.CustomFilter(x => x%2 == 0).CustomSelect(x => x*2); 
var sum = test.CustomReduce((acc, current) => acc + current, 0);

foreach(var element in test)
{
    Console.WriteLine(element);
}

Console.WriteLine($"\nSum is {sum}");