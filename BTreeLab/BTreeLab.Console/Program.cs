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

keys = "21,73,23,15,66,72,34,1,79,64,95,35,8,2,84,26,52,97,51,88,80,36,24,62,94,89,76,75,70,63,49,91,33,43,27,92,9,25,78,65,3,45,53,90,55,38,74,59,69,93".Split(",").Select(int.Parse).ToList();
keys = "21,73,23,15,66,72,34,1,79,64,95,35,8,2,84,26,52,97,51,88,80,36,24,62,94,89,76,75,70,63,49,91,33,43,27,92,9,25,78,65,3,45,53,90,55,38,74,59,69,93".Split(",").Select(int.Parse).ToList();

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
            treeMap[level] += " | ";
        }

        treeMap[level] += string.Join(",", node.Keys).Trim(',');

        foreach (var child in node.Children)
        {
            GenerateTreeMap(child, level + 1);
        }
    }
}