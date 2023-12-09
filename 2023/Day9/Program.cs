
using Day9.Domain;

OasisReport oReport = new OasisReport();
var numbers = oReport.ParseLinesToSeriesAndCalcultateNextNumber(File.ReadLines(@"Inputs\Input.txt").ToList());

var result1 = numbers.Sum();
Console.WriteLine(result1);

numbers = oReport.ParseLinesToSeriesAndCalcultateFirstNumber(File.ReadLines(@"Inputs\Input.txt").ToList());

var result2 = numbers.Sum();
Console.WriteLine(result2);
Console.ReadLine();
