// See https://aka.ms/new-console-template for more information

using BTreeLab;

//var btree = new BTreeG<int>(4);
var btree = new BTree(4);

var keys = new List<int>();

while (keys.Count < 100)
{
    var key = Random.Shared.Next(1, 1000);

    if (keys.Contains(key)) continue;

    keys.Add(key);
}

keys = "96,18,80,46,26,8,81,30,12,10,59,34,71,45,31,66,90,43,72,29,47,11,77,19,14,54,6,87,91,36,24,3,21,64,40,48,98,88,20,25,27,23,79,73,5,86,70,94,15,69".Split(",").Select(int.Parse).ToList();

Console.WriteLine(string.Join(",", keys));
Console.WriteLine();

//var keys = Enumerable.Range(1, 9).ToList();

foreach (var key in keys)
{
    //btree.Insert(key);
    btree.Add(key);
}

PrintTree(btree);
Console.WriteLine();
Console.ReadLine();

btree.Remove(64);
btree.Remove(66);

PrintTree(btree);
Console.WriteLine();
Console.ReadLine();

btree.Remove(59);

PrintTree(btree);
Console.WriteLine();
Console.ReadLine();

void PrintTree(BTree btree)
{
    var treeMap = Enumerable.Range(1, 100).Select(i => string.Empty).ToArray();

    GenerateTreeMap(btree.Root, 0);

    foreach (var map in treeMap)
    {
        if (string.IsNullOrEmpty(map)) continue;

        Console.WriteLine(map);
    }

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
}
