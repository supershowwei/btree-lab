// See https://aka.ms/new-console-template for more information

using BTreeLab;

//var btree = new BTreeG<int>(4);
var btree = new BTree(5);

var keys = new List<int>();

while (keys.Count < 30)
{
    var key = Random.Shared.Next(1, 100);

    if (keys.Contains(key)) continue;

    keys.Add(key);
}

//var keys = Enumerable.Range(1, 9).ToList();

keys = "43,91,95,84,75,51,78,15,49,98,39,7,60,11,28,23,47,34,17,94,92,63,5,57,1,41,90,36,61,53".Split(",").Select(int.Parse).ToList();

Console.WriteLine(string.Join(",", keys));

foreach (var key in keys)
{
    if (key == 61)
    {
        
    }
    //btree.Insert(key);
    btree.Add(key);
}

Console.WriteLine("Hello, World!");
