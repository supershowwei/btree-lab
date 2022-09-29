namespace BTreeLab;

public class BTree
{
    private readonly int maxKeyLength;
    private BTreeNode root;

    public BTree(int maxKeyLength)
    {
        this.maxKeyLength = maxKeyLength;
    }

    public void Add(int key)
    {
        BTreeNode node;

        if (this.root == null)
        {
            this.root = new BTreeNode(this.maxKeyLength);

            node = this.root;
        }
        else
        {
            node = FindLeaf(this.root, key);
        }

        node.Add(key);

        this.Count++;
    }

    private static BTreeNode FindLeaf(BTreeNode node, int key)
    {
        if (node.IsLeaf) return node;

        var index = 0;

        for (; index < node.KeyCount; index++)
        {
            if (key.CompareTo(node.Keys[index]) < 0)
            {
                return FindLeaf(node.Children[index], key);
            }
        }

        return FindLeaf(node.Children[index], key);
    }

    public int Count { get; private set; }
}

public class BTreeNode
{
    private readonly int maxKeyLength;

    public BTreeNode(int maxKeyLength)
    {
        this.maxKeyLength = maxKeyLength;
        this.Keys = new int?[maxKeyLength];
        this.Children = new BTreeNode[maxKeyLength + 1];
    }

    public int?[] Keys { get; }

    public BTreeNode[] Children { get; }

    public int KeyCount { get; private set; }

    public bool IsLeaf => this.Children[0] == null;

    public void Add(int key)
    {
        if (this.KeyCount < this.maxKeyLength)
        {
            var index = 0;

            for (; index < this.KeyCount; index++)
            {
                var comparison = key.CompareTo(this.Keys[index]);

                if (comparison == 0) return;
                if (comparison < 0) break;
            }

            for (var i = index; i < this.KeyCount; i++)
            {
                (this.Keys[index], this.Keys[i + 1]) = (this.Keys[i + 1], this.Keys[index]);
            }

            this.Keys[index] = key;
            this.KeyCount++;
        }
        else
        {
            var median = this.KeyCount / 2 + 1;


        }

        throw new NotImplementedException();
    }
}