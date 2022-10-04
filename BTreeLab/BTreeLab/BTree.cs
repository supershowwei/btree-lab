namespace BTreeLab;

public class BTree
{
    private readonly int maxKeyLength;

    public BTree(int maxKeyLength)
    {
        this.maxKeyLength = maxKeyLength;
    }

    public BTreeNode Root { get; private set; }

    public int Count { get; private set; }

    public void Add(int key)
    {
        BTreeNode node;

        if (this.Root == null)
        {
            this.Root = new BTreeNode(this.maxKeyLength, null);

            node = this.Root;
        }
        else
        {
            node = FindLeaf(this.Root, key);
        }

        node.Add(key);

        this.Count++;
    }

    private static BTreeNode FindLeaf(BTreeNode node, int key)
    {
        if (node.IsLeaf) return node;

        var index = 0;
        var keyCount = node.GetKeyCount();

        for (; index < keyCount; index++)
        {
            if (key.CompareTo(node.Keys[index]) < 0)
            {
                return FindLeaf(node.Children[index], key);
            }
        }

        return FindLeaf(node.Children[index], key);
    }
}

public class BTreeNode
{
    private readonly int maxKeyLength;

    public BTreeNode(int maxKeyLength, BTreeNode parent)
    {
        this.maxKeyLength = maxKeyLength;
        this.Keys = new int?[maxKeyLength];
        this.Parent = parent;
        this.Children = new BTreeNode[maxKeyLength + 1];
    }

    public int?[] Keys { get; }

    public BTreeNode Parent { get; private set; }

    public BTreeNode[] Children { get; }

    public bool IsRoot => this.Parent == null;

    public bool IsLeaf => this.Children[0] == null;

    public int GetKeyCount() => this.Keys.Count(k => k.HasValue);

    public int Add(int key)
    {
        var keyCount = this.GetKeyCount();

        if (keyCount < this.maxKeyLength)
        {
            var index = 0;

            for (; index < keyCount; index++)
            {
                var comparison = key.CompareTo(this.Keys[index]);

                if (comparison == 0) return -1;

                if (comparison < 0) break;
            }

            for (var i = keyCount; i > index; i--)
            {
                this.Keys[i] = this.Keys[i - 1];
                this.Children[i + 1] = this.Children[i];
            }

            this.Keys[index] = key;
            this.Children[index] = default;

            return index;
        }
        else
        {
            var medianIndex = keyCount / 2;

            var index = 0;

            var leftNode = new BTreeNode(this.maxKeyLength, this);

            leftNode.SetChild(0, this.Children[index]);

            for (var i = index; index < medianIndex; index++)
            {
                leftNode.Keys[i] = this.Keys[index];
                leftNode.SetChild(i + 1, this.Children[index + 1]);

                i++;
            }

            index++;

            var rightNode = new BTreeNode(this.maxKeyLength, this);

            rightNode.SetChild(0, this.Children[index]);

            for (var i = 0; index < keyCount; index++)
            {
                rightNode.Keys[i] = this.Keys[index];
                rightNode.SetChild(i + 1, this.Children[index + 1]);

                i++;
            }

            var medianKey = this.Keys[medianIndex];

            Array.Clear(this.Keys);
            Array.Clear(this.Children);

            if (this.IsRoot)
            {
                this.Keys[0] = medianKey;
                this.Children[0] = leftNode;
                this.Children[1] = rightNode;
            }
            else
            {
                var parentIndex = this.Parent.Add(medianKey.Value);

                this.Parent.SetChild(parentIndex, leftNode);
                this.Parent.SetChild(parentIndex + 1, rightNode);
            }

            if (key < medianKey)
            {
                return leftNode.Add(key);
            }
            else if (key > medianKey)
            {
                return rightNode.Add(key);
            }

            return -1;
        }
    }

    private void SetChild(int index, BTreeNode child)
    {
        if (child != null)
        {
            child.Parent = this;
        }

        this.Children[index] = child;
    }
}