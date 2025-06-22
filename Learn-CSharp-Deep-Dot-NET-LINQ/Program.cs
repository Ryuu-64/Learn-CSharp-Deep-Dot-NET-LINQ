// See https://aka.ms/new-console-template for more information

using Learn_CSharp_Deep_Dot_NET_LINQ;

IEnumerable<int> source = Enumerable.Range(0, 1000).ToArray();
Console.WriteLine(Enumerable.Select(source, i => i * 2).Sum());
Console.WriteLine(MyLinq.SelectCompiler(source, i => i * 2).Sum());
Console.WriteLine(MyLinq.SelectManual(source, i => i * 2).Sum());