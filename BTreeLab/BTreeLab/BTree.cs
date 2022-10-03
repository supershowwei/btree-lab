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
            this.root = new BTreeNode(this.maxKeyLength, null);

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

    public int Count { get; private set; }
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

            leftNode.Children[0] = this.Children[index];

            for (var i = index; index < medianIndex; index++)
            {
                leftNode.Keys[i] = this.Keys[index];

                var child = this.Children[index + 1];

                if (child != null)
                {
                    child.Parent = leftNode;
                }

                leftNode.Children[i + 1] = child;

                i++;
            }

            var rightNode = new BTreeNode(this.maxKeyLength, this);

            rightNode.Children[0] = this.Children[index];

            index++;

            for (var i = 0; index < keyCount; index++)
            {
                rightNode.Keys[i] = this.Keys[index];

                var child = this.Children[index + 1];

                if (child != null)
                {
                    child.Parent = rightNode;
                }

                rightNode.Children[i + 1] = child;

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
                var indexInParent = this.Parent.Add(medianKey.Value);

                this.Parent.Children[indexInParent] = leftNode;
                leftNode.Parent = this.Parent;

                this.Parent.Children[indexInParent + 1] = rightNode;
                rightNode.Parent = this.Parent;
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
}