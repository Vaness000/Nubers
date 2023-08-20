using DataLayer;

var cancelTokenSource = new CancellationTokenSource();
var provider = new DbProvider();
await provider.InitAsync(cancelTokenSource.Token);

var numbers = provider.GetTopTenFrequenceNumbers();
foreach(var number in numbers)
{
    Console.WriteLine($"{number.Key} - {number.Value}");
}
Console.WriteLine();
//var frequence = provider.GetFrequencyNumbersAsync(10, cancelTokenSource.Token);
//await foreach(var elem in frequence)
//{
//    Console.WriteLine($"{elem.Key} - {elem.Value}");
//}

//Console.WriteLine();

//var elemsByFrequence = provider.GetNumberByFrequenceAsync(100, cancelTokenSource.Token);
//await foreach (var elem in elemsByFrequence)
//{
//    Console.WriteLine(elem);
//}

//Console.WriteLine();

//var number = await provider.GetFrequenceByNumber(69828, cancelTokenSource.Token);

//Console.WriteLine(number);