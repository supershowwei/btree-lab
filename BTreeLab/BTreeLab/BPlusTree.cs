using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("BTreeLab.Console")]
[assembly: InternalsVisibleTo("BTreeLab.Tests")]

namespace BTreeLab;

public class BPlusTree
{
    private readonly BPlusTreeNode root;

    public BPlusTree(int degree)
    {
        this.root = new BPlusTreeNode(degree, null);
    }

    public int Count { get; private set; }

    // For Testing and Debugging
    internal BPlusTreeNode Root => this.root;

    public void Add(int key)
    {
        var node = FindLeaf(this.root, key);

        node.Add(key);

        this.Count++;
    }

    public void Remove(int key)
    {
        BPlusTreeNode node;
        int index;

        if (this.root == null)
        {
            throw new ArgumentNullException(nameof(this.root));
        }
        else
        {
            node = FindNode(this.root, key, out index);
        }

        if (node != null)
        {
            node.RemoveAt(index);

            this.Count--;
        }
    }

    public int Find(int key)
    {
        return Find(this.root);

        int Find(BPlusTreeNode node)
        {
            var i = 0;

            for (; i < node.KeyCount; i++)
            {
                var comparison = key.CompareTo(node.Keys[i]);

                if (comparison == 0)
                {
                    return node.Keys[i].Value;
                }

                if (comparison < 0)
                {
                    if (!node.IsLeaf)
                    {
                        return Find(node.Children[i]);
                    }
                }
            }

            if (!node.IsLeaf)
            {
                return Find(node.Children[i]);
            }

            return -1;
        }
    }

    public IEnumerable<int> GreaterThan(int key)
    {
        var leaf = FindLeaf(this.root, key);

        for (var i = 0; i < leaf.KeyCount; i++)
        {
            if (leaf.Keys[i] > key) yield return leaf.Keys[i].Value;
        }

        while (leaf.Next != null)
        {
            leaf = leaf.Next;

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                yield return leaf.Keys[i].Value;
            }
        }
    }

    private static BPlusTreeNode FindLeaf(BPlusTreeNode node, int key)
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

    private static BPlusTreeNode FindNode(BPlusTreeNode node, int key, out int index)
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

        if (!node.IsLeaf)
        {
            return FindNode(node.Children[i], key, out index);
        }

        index = -1;
        return null;
    }
}

internal class BPlusTreeNode
{
    private readonly int maxKeyLength;
    private readonly int minKeyLength;

    public BPlusTreeNode(int degree, BPlusTreeNode parent)
    {
        this.maxKeyLength = degree;
        this.minKeyLength = (int)Math.Ceiling(degree / 2d) - 1;
        this.Keys = new int?[degree];
        this.Parent = parent;
        this.Children = new BPlusTreeNode[degree + 1];
    }

    public int?[] Keys { get; }

    public int KeyCount { get; private set; }

    public BPlusTreeNode[] Children { get; }

    public BPlusTreeNode Parent { get; private set; }

    public BPlusTreeNode Previous { get; private set; }

    public BPlusTreeNode Next { get; private set; }

    public bool IsRoot => this.Parent == null;

    public bool IsLeaf => this.Children[0] == null;

    public void Add(int key)
    {
        this.Insert(key);

        this.SplitIfNecessary();
    }

    public void RemoveAt(int index)
    {
        if (this.IsLeaf)
        {
            this.DeleteAt(index);

            this.MergeIfNecessary();
        }
        else
        {
            this.Keys[index] = default;

            var rightLeaf = FindRightLeaf();

            rightLeaf.DeleteAt(0);

            rightLeaf.MergeIfNecessary(this, index);
        }

        BPlusTreeNode FindRightLeaf()
        {
            var leaf = this.Children[index + 1];

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            return leaf;
        }
    }

    private void MergeIfNecessary(BPlusTreeNode internalNode = null, int internalIndex = -1)
    {
        if (this.IsRoot) return;

        if (this.KeyCount >= this.minKeyLength)
        {
            SetInternalNode(this.Keys[0]);

            return;
        }

        var childIndexInParent = this.FindChildIndexInParent();

        var leftSibling = childIndexInParent > 0 ? this.Parent.Children[childIndexInParent - 1] : default;
        var rightSibling = childIndexInParent < this.maxKeyLength ? this.Parent.Children[childIndexInParent + 1] : default;

        if (leftSibling != null && leftSibling.KeyCount > this.minKeyLength)
        {
            if (this.KeyCount == 0)
            {
                this.Children[1] = this.Children[0];
            }

            if (internalNode == null)
            {
                var parentKeyIndex = childIndexInParent - 1;

                this.Insert(this.Parent.Keys[parentKeyIndex].Value);
                this.Parent.Keys[parentKeyIndex] = leftSibling.Keys[leftSibling.KeyCount - 1];
            }
            else
            {
                SetInternalNode(leftSibling.Keys[leftSibling.KeyCount - 1]);

                this.Insert(leftSibling.Keys[leftSibling.KeyCount - 1].Value);
            }

            SetChild(this, 0, leftSibling.Children[leftSibling.KeyCount]);

            leftSibling.Children[leftSibling.KeyCount] = default;
            leftSibling.DeleteAt(leftSibling.KeyCount - 1);
        }
        else if (rightSibling != null && rightSibling.KeyCount > this.minKeyLength)
        {
            var parentKeyIndex = childIndexInParent;

            if (internalNode == null)
            {
                this.Insert(this.Parent.Keys[parentKeyIndex].Value);
                this.Parent.Keys[parentKeyIndex] = rightSibling.Keys[0];
            }
            else
            {
                SetInternalNode(rightSibling.Keys[0]);

                this.Insert(rightSibling.Keys[0].Value);
                this.Parent.Keys[parentKeyIndex] = rightSibling.Keys[1];
            }

            SetChild(this, this.KeyCount, rightSibling.Children[0]);

            for (var i = 0; i < rightSibling.KeyCount; i++)
            {
                rightSibling.Children[i] = rightSibling.Children[i + 1];
            }

            rightSibling.Children[rightSibling.KeyCount] = rightSibling.Children[rightSibling.KeyCount + 1];
            rightSibling.DeleteAt(0);
        }
        else
        {
            var parentKeyIndex = leftSibling != null ? childIndexInParent - 1 : childIndexInParent;

            var mergedNode = leftSibling ?? this;
            var manureNode = mergedNode == this ? rightSibling : this;

            if (this.Parent.Keys[parentKeyIndex] != default && this.Parent.Keys[parentKeyIndex] != manureNode.Keys[0])
            {
                mergedNode.Keys[mergedNode.KeyCount] = this.Parent.Keys[parentKeyIndex];
                mergedNode.KeyCount++;

                SetChild(mergedNode, mergedNode.KeyCount, manureNode.Children[0]);
            }

            for (var i = 0; i < manureNode.KeyCount; i++)
            {
                mergedNode.Keys[mergedNode.KeyCount] = manureNode.Keys[i];
                mergedNode.KeyCount++;

                SetChild(mergedNode, mergedNode.KeyCount, manureNode.Children[i + 1]);
            }

            mergedNode.Next = manureNode.Next;

            if (mergedNode.Next != null)
            {
                mergedNode.Next.Previous = mergedNode;
            }

            SetInternalNode(mergedNode.Keys[0]);

            for (var i = parentKeyIndex; i < this.Parent.KeyCount; i++)
            {
                this.Parent.Children[i] = this.Parent.Children[i + 1];
            }

            this.Parent.Children[this.Parent.KeyCount] = default;
            this.Parent.Children[parentKeyIndex] = mergedNode;
            this.Parent.DeleteAt(parentKeyIndex);

            if (this.Parent.IsRoot && this.Parent.KeyCount == 0)
            {
                Array.Clear(this.Parent.Keys, 0, this.Parent.Keys.Length);
                Array.Clear(this.Parent.Children, 0, this.Parent.Children.Length);

                for (var i = 0; i < mergedNode.KeyCount; i++)
                {
                    this.Parent.Keys[i] = mergedNode.Keys[i];

                    SetChild(this.Parent, i, mergedNode.Children[i]);
                }

                SetChild(this.Parent, mergedNode.KeyCount, mergedNode.Children[mergedNode.KeyCount]);

                this.Parent.KeyCount = mergedNode.KeyCount;
            }
            else
            {
                this.Parent.MergeIfNecessary();
            }
        }

        void SetInternalNode(int? key)
        {
            if (internalNode == null) return;

            internalNode.Keys[internalIndex] = key;
        }
    }

    private static void SetChild(BPlusTreeNode node, int childIndex, BPlusTreeNode child)
    {
        if (child != null)
        {
            child.Parent = node;
        }

        node.Children[childIndex] = child;
    }

    private int FindChildIndexInParent()
    {
        for (var i = 0; i < this.Parent.Children.Length; i++)
        {
            if (this.Parent.Children[i] == this) return i;
        }

        return -1;
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

        if (this.KeyCount > 0)
        {
            for (var i = this.KeyCount; i > index; i--)
            {
                this.Keys[i] = this.Keys[i - 1];
                this.Children[i + 1] = this.Children[i];
            }

            this.Children[index + 1] = this.Children[index];
            this.Children[index] = default;
        }

        this.Keys[index] = key;
        this.KeyCount++;

        return index;
    }

    private void DeleteAt(int index)
    {
        this.KeyCount--;

        for (var i = index; i < this.KeyCount; i++)
        {
            this.Keys[i] = this.Keys[i + 1];
        }

        this.Keys[this.KeyCount] = default;
    }

    private void SplitIfNecessary()
    {
        if (this.KeyCount < this.maxKeyLength) return;

        var medianIndex = this.KeyCount / 2;

        var index = 0;

        var leftNode = new BPlusTreeNode(this.maxKeyLength, this);

        SetChild(leftNode, 0, this.Children[index]);

        for (var i = index; index < medianIndex; index++)
        {
            leftNode.Keys[i] = this.Keys[index];
            leftNode.KeyCount++;

            SetChild(leftNode, i + 1, this.Children[index + 1]);

            i++;
        }

        index++;

        var rightNode = new BPlusTreeNode(this.maxKeyLength, this);

        SetChild(rightNode, 0, this.Children[index]);

        for (var i = 0; index < this.KeyCount; index++)
        {
            rightNode.Keys[i] = this.Keys[index];
            rightNode.KeyCount++;

            SetChild(rightNode, i + 1, this.Children[index + 1]);

            i++;
        }

        var medianKey = this.Keys[medianIndex];

        if (this.IsLeaf)
        {
            rightNode.Insert(medianKey.Value);

            rightNode.Previous = leftNode;
            leftNode.Next = rightNode;

            if (this.Previous != null)
            {
                leftNode.Previous = this.Previous;

                this.Previous.Next = leftNode;
                this.Previous = null;
            }

            if (this.Next != null)
            {
                rightNode.Next = this.Next;

                this.Next.Previous = rightNode;
                this.Next = null;
            }
        }

        if (this.IsRoot)
        {
            Array.Clear(this.Keys, 0, this.Keys.Length);
            Array.Clear(this.Children, 0, this.Children.Length);

            this.Keys[0] = medianKey;
            this.Children[0] = leftNode;
            this.Children[1] = rightNode;

            this.KeyCount = 1;
        }
        else
        {
            var keyIndexInParent = this.Parent.Insert(medianKey.Value);

            SetChild(this.Parent, keyIndexInParent, leftNode);
            SetChild(this.Parent, keyIndexInParent + 1, rightNode);

            this.Parent.SplitIfNecessary();
        }
    }
}