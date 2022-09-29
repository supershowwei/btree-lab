// See https://aka.ms/new-console-template for more information

using BTreeLab;

var btree = new BTreeG<int>(3);

var keys = Enumerable.Range(0, 10).Select(x => Random.Shared.Next(1, 3));

foreach (var key in keys)
{
    btree.Insert(key);
}

Console.WriteLine("Hello, World!");
