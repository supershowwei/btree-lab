namespace BTreeLab;

public class BTree
{
    private readonly int degree;

    public BTree(int degree)
    {
        this.degree = degree;
    }

    public BTreeNode Root { get; private set; }

    public int Count { get; private set; }

    public void Add(int key)
    {
        BTreeNode node;

        if (this.Root == null)
        {
            this.Root = new BTreeNode(this.degree, null);

            node = this.Root;
        }
        else
        {
            node = FindLeaf(this.Root, key);
        }

        node.Add(key);

        this.Count++;
    }

    public void Remove(int key)
    {
        BTreeNode node;
        int index;

        if (this.Root == null)
        {
            throw new ArgumentNullException(nameof(this.Root));
        }
        else
        {
            node = FindNode(this.Root, key, out index);
        }

        if (node != null)
        {
            node.RemoveAt(index);

            this.Count--;
        }
    }

    private static BTreeNode FindLeaf(BTreeNode node, int key)
    {
        if (node.IsLeaf) return node;

        var i = 0;

        for (; i < node.KeyCount; i++)
        {
            if (key.CompareTo(node.Keys[i]) < 0)
            {
                return FindLeaf(node.Children[i], key);
            }
        }

        return FindLeaf(node.Children[i], key);
    }

    private static BTreeNode FindNode(BTreeNode node, int key, out int index)
    {
        var i = 0;

        for (; i < node.KeyCount; i++)
        {
            var comparison = key.CompareTo(node.Keys[i]);

            if (comparison == 0)
            {
                index = i;
                return node;
            }

            if (comparison < 0)
            {
                return FindNode(node.Children[i], key, out index);
            }
        }

        index = -1;
        return null;
    }
}

public class BTreeNode
{
    private readonly int maxKeyLength;
    private readonly int minKeyLength;

    public BTreeNode(int degree, BTreeNode parent)
    {
        this.maxKeyLength = degree;
        this.minKeyLength = (int)Math.Ceiling(degree / 2d) - 1;
        this.Keys = new int?[degree];
        this.Parent = parent;
        this.Children = new BTreeNode[degree + 1];
    }

    public int?[] Keys { get; }

    public BTreeNode Parent { get; private set; }

    public BTreeNode[] Children { get; }

    public bool IsRoot => this.Parent == null;

    public bool IsLeaf => this.Children[0] == null;

    public int KeyCount { get; private set; }

    public void Add(int key)
    {
        this.Insert(key);

        this.SplitIfNecessary();
    }

    public void RemoveAt(int index)
    {
        // 刪除的是葉節點
        // 如果不富有，
        if (this.IsLeaf)
        {
            this.KeyCount--;

            for (var i = index; i < this.KeyCount; i++)
            {
                this.Keys[index] = this.Keys[index + 1];
            }

            this.Keys[this.KeyCount] = default;

            if (this.KeyCount < this.minKeyLength)
            {

            }
        }
        else
        {

        }
    }

    private int Insert(int key)
    {
        var index = 0;

        for (; index < this.KeyCount; index++)
        {
            var comparison = key.CompareTo(this.Keys[index]);

            if (comparison == 0) return -1;

            if (comparison < 0) break;
        }

        for (var i = this.KeyCount; i > index; i--)
        {
            this.Keys[i] = this.Keys[i - 1];
            this.Children[i + 1] = this.Children[i];
        }

        this.Keys[index] = key;
        this.KeyCount++;

        this.Children[index] = default;

        return index;
    }

    private void SplitIfNecessary()
    {
        if (this.KeyCount < this.maxKeyLength) return;

        var medianIndex = (int)Math.Ceiling(this.KeyCount / 2d) - 1;

        var index = 0;

        var leftNode = new BTreeNode(this.maxKeyLength, this);

        SetChild(leftNode, 0, this.Children[index]);

        for (var i = index; index < medianIndex; index++)
        {
            leftNode.Keys[i] = this.Keys[index];
            leftNode.KeyCount++;

            SetChild(leftNode, i + 1, this.Children[index + 1]);

            i++;
        }
        
        index++;

        var rightNode = new BTreeNode(this.maxKeyLength, this);

        SetChild(rightNode, 0, this.Children[index]);

        for (var i = 0; index < this.KeyCount; index++)
        {
            rightNode.Keys[i] = this.Keys[index];
            rightNode.KeyCount++;

            SetChild(rightNode, i + 1, this.Children[index + 1]);

            i++;
        }

        var medianKey = this.Keys[medianIndex];

        if (this.IsRoot)
        {
            Array.Clear(this.Keys);
            Array.Clear(this.Children);

            this.Keys[0] = medianKey;
            this.Children[0] = leftNode;
            this.Children[1] = rightNode;

            this.KeyCount = 1;
        }
        else
        {
            var parentIndex = this.Parent.Insert(medianKey.Value);

            SetChild(this.Parent, parentIndex, leftNode);
            SetChild(this.Parent, parentIndex + 1, rightNode);

            this.Parent.SplitIfNecessary();
        }

        void SetChild(BTreeNode node, int index, BTreeNode child)
        {
            if (child != null)
            {
                child.Parent = node;
            }

            node.Children[index] = child;
        }
    }
}