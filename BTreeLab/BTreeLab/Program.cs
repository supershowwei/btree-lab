// See https://aka.ms/new-console-template for more information

using BTreeLab;

//var btree = new BTreeG<int>(4);
var btree = new BTree(5);

var keys = new List<int>();

while (keys.Count < 150)
{
    var key = Random.Shared.Next(1, 1000);

    if (keys.Contains(key)) continue;

    keys.Add(key);
}

//var keys = Enumerable.Range(1, 9).ToList();

foreach (var key in keys)
{
    //btree.Insert(key);
    btree.Add(key);
}

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
