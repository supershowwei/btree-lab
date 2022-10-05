// See https://aka.ms/new-console-template for more information

using BTreeLab;

//var btree = new BTreeG<int>(4);
var btree = new BTree(5);

var keys = new List<int>();

while (keys.Count < 100)
{
    var key = Random.Shared.Next(1, 1000);

    if (keys.Contains(key)) continue;

    keys.Add(key);
}

keys = "60,67,5,76,66,59,58,90,11,81,40,57,2,6,43,74,85,75,70,18,31,64,95,84,54,99,86,48,52,93".Split(",").Select(int.Parse).ToList();

Console.WriteLine(string.Join(",", keys));

//var keys = Enumerable.Range(1, 9).ToList();

foreach (var key in keys)
{
    //btree.Insert(key);
    btree.Add(key);
}

btree.Remove(81);

var treeMap = Enumerable.Range(1, 100).Select(i => string.Empty).ToArray();

GenerateTreeMap(btree.Root, 0);

foreach (var map in treeMap)
{
    if (string.IsNullOrEmpty(map)) continue;

    Console.WriteLine(map);
}

Console.ReadLine();

void GenerateTreeMap(BTreeNode node, int level)
{
    if (node == null) return;

    if (treeMap[level] != string.Empty)
    {
        treeMap[level] += "  ";
    }

    treeMap[level] += string.Join(",", node.Keys);

    foreach (var child in node.Children)
    {
        GenerateTreeMap(child, level + 1);
    }
}
