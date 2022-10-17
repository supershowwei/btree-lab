using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTreeLab.Tests
{
    [TestClass]
    public class FourDegreesBPlusTreeTest
    {
        private static readonly List<int> Keys = "21,73,23,15,66,72,34,1,79,64,95,35,8,2,84,26,52,97,51,88,80,36,24,62,94,89,76,75,70,63,49,91,33,43,27,92,9,25,78,65,3,45,53,90,55,38,74,59,69,93".Split(",").Select(int.Parse).ToList();

        [TestMethod]
        public void Test_Add_Key()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,72");
            treeMap[1].Should().Be("23,34 | 62 | 89");
            treeMap[2].Should().Be("8,15 | 26 | 36,45 | 53 | 64,66 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8,9 | 15,21 | 23,24,25 | 26,27,33 | 34,35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 66,69,70 | 72,73,74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", Keys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_1()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 1; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,72");
            treeMap[1].Should().Be("23,34 | 62 | 89");
            treeMap[2].Should().Be("8,15 | 26 | 36,45 | 53 | 64,66 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8,9 | 15 | 23,24,25 | 26,27,33 | 34,35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 66,69,70 | 72,73,74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_2()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 2; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,72");
            treeMap[1].Should().Be("23,34 | 62 | 89");
            treeMap[2].Should().Be("8,15 | 26 | 36,45 | 53 | 64,66 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8,9 | 15 | 23,24,25 | 26,27,33 | 34,35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 66,69,70 | 72,74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_3()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 3; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,72");
            treeMap[1].Should().Be("24,34 | 62 | 89");
            treeMap[2].Should().Be("8,15 | 26 | 36,45 | 53 | 64,66 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8,9 | 15 | 24,25 | 26,27,33 | 34,35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 66,69,70 | 72,74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_4()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 4; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,72");
            treeMap[1].Should().Be("24,34 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 64,66 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8 | 9 | 24,25 | 26,27,33 | 34,35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 66,69,70 | 72,74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_5()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 5; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,72");
            treeMap[1].Should().Be("24,34 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 64,69 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8 | 9 | 24,25 | 26,27,33 | 34,35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 69,70 | 72,74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_6()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 6; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,34 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 64,69 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8 | 9 | 24,25 | 26,27,33 | 34,35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 69,70 | 74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_7()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 7; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,35 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 64,69 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("1,2,3 | 8 | 9 | 24,25 | 26,27,33 | 35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 69,70 | 74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_8()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 8; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,35 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 64,69 | 75,79,84 | 92,95");
            treeMap[3].Should().Be("2,3 | 8 | 9 | 24,25 | 26,27,33 | 35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 69,70 | 74 | 75,76,78 | 79,80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_9()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 9; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,35 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 64,69 | 75,80,84 | 92,95");
            treeMap[3].Should().Be("2,3 | 8 | 9 | 24,25 | 26,27,33 | 35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 64,65 | 69,70 | 74 | 75,76,78 | 80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_10()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 10; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,35 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 65,69 | 75,80,84 | 92,95");
            treeMap[3].Should().Be("2,3 | 8 | 9 | 24,25 | 26,27,33 | 35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 84,88 | 89,90,91 | 92,93,94 | 95,97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_11()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 11; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,35 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 36,45 | 53 | 65,69 | 75,80,84 | 92,97");
            treeMap[3].Should().Be("2,3 | 8 | 9 | 24,25 | 26,27,33 | 35 | 36,38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 84,88 | 89,90,91 | 92,93,94 | 97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_12()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 12; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("8,9 | 26 | 38,45 | 53 | 65,69 | 75,80,84 | 92,97");
            treeMap[3].Should().Be("2,3 | 8 | 9 | 24,25 | 26,27,33 | 36 | 38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 84,88 | 89,90,91 | 92,93,94 | 97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_13()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 13; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("3,9 | 26 | 38,45 | 53 | 65,69 | 75,80,84 | 92,97");
            treeMap[3].Should().Be("2 | 3 | 9 | 24,25 | 26,27,33 | 36 | 38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 84,88 | 89,90,91 | 92,93,94 | 97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_14()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 14; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 26 | 38,45 | 53 | 65,69 | 75,80,84 | 92,97");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 26,27,33 | 36 | 38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 84,88 | 89,90,91 | 92,93,94 | 97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_15()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 15; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 26 | 38,45 | 53 | 65,69 | 75,80,88 | 92,97");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 26,27,33 | 36 | 38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 88 | 89,90,91 | 92,93,94 | 97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_16()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 16; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 38,45 | 53 | 65,69 | 75,80,88 | 92,97");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 27,33 | 36 | 38,43 | 45,49 | 51,52 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 88 | 89,90,91 | 92,93,94 | 97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_17()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 17; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 38,45 | 53 | 65,69 | 75,80,88 | 92,97");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 27,33 | 36 | 38,43 | 45,49 | 51 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 88 | 89,90,91 | 92,93,94 | 97");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_18()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 18; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("51,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 38,45 | 53 | 65,69 | 75,80,88 | 92,94");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 27,33 | 36 | 38,43 | 45,49 | 51 | 53,55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 88 | 89,90,91 | 92,93 | 94");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_19()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 19; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 38,45 | 55 | 65,69 | 75,80,88 | 92,94");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 27,33 | 36 | 38,43 | 45,49 | 53 | 55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 88 | 89,90,91 | 92,93 | 94");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_20()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 20; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 38,45 | 55 | 65,69 | 75,80 | 92,94");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 27,33 | 36 | 38,43 | 45,49 | 53 | 55,59 | 62,63 | 65 | 69,70 | 74 | 75,76,78 | 80 | 89,90,91 | 92,93 | 94");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_21()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 21; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("24,36 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 38,45 | 55 | 65,69 | 75,78 | 92,94");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 27,33 | 36 | 38,43 | 45,49 | 53 | 55,59 | 62,63 | 65 | 69,70 | 74 | 75,76 | 78 | 89,90,91 | 92,93 | 94");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_22()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 22; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("24,38 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 75,78 | 92,94");
            treeMap[3].Should().Be("3 | 9 | 24,25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 62,63 | 65 | 69,70 | 74 | 75,76 | 78 | 89,90,91 | 92,93 | 94");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_23()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 23; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 62 | 89");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 75,78 | 92,94");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 62,63 | 65 | 69,70 | 74 | 75,76 | 78 | 89,90,91 | 92,93 | 94");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_24()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 24; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 63 | 89");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 75,78 | 92,94");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 63 | 65 | 69,70 | 74 | 75,76 | 78 | 89,90,91 | 92,93 | 94");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_25()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 25; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 63 | 89");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 75,78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 63 | 65 | 69,70 | 74 | 75,76 | 78 | 89,90,91 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_26()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 26; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 63 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 75,78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 63 | 65 | 69,70 | 74 | 75,76 | 78 | 90,91 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_27()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 27; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 63 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 75,78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 63 | 65 | 69,70 | 74 | 75 | 78 | 90,91 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_28()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 28; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 63 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 63 | 65 | 69,70 | 74 | 78 | 90,91 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_29()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 29; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 63 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 65,69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 63 | 65 | 69 | 74 | 78 | 90,91 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_30()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 30; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 65 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45,49 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90,91 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_31()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 31; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 65 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90,91 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_32()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 32; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 65 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27,33 | 38 | 43 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_33()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 33; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 65 | 90");
            treeMap[2].Should().Be("9 | 27 | 43,45 | 55 | 69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27 | 38 | 43 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_34()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 34; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("25,38 | 65 | 90");
            treeMap[2].Should().Be("9 | 27 | 45 | 55 | 69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 27 | 38 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_35()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 35; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("38 | 65 | 90");
            treeMap[2].Should().Be("9,25 | 45 | 55 | 69 | 78 | 92,93");
            treeMap[3].Should().Be("3 | 9 | 25 | 38 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90 | 92 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_36()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 36; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("38 | 65 | 90");
            treeMap[2].Should().Be("9,25 | 45 | 55 | 69 | 78 | 93");
            treeMap[3].Should().Be("3 | 9 | 25 | 38 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_37()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 37; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("53,74");
            treeMap[1].Should().Be("38 | 65 | 90");
            treeMap[2].Should().Be("25 | 45 | 55 | 69 | 78 | 93");
            treeMap[3].Should().Be("3 | 25 | 38 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_38()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 38; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("74");
            treeMap[1].Should().Be("53,65 | 90");
            treeMap[2].Should().Be("38,45 | 55 | 69 | 78 | 93");
            treeMap[3].Should().Be("3 | 38 | 45 | 53 | 55,59 | 65 | 69 | 74 | 78 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_39()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 39; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("53 | 74");
            treeMap[2].Should().Be("38,45 | 55 | 69 | 90,93");
            treeMap[3].Should().Be("3 | 38 | 45 | 53 | 55,59 | 65 | 69 | 74 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_40()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 40; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("69");
            treeMap[1].Should().Be("53 | 90");
            treeMap[2].Should().Be("38,45 | 55 | 74 | 93");
            treeMap[3].Should().Be("3 | 38 | 45 | 53 | 55,59 | 69 | 74 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_41()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 41; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("69");
            treeMap[1].Should().Be("53 | 90");
            treeMap[2].Should().Be("45 | 55 | 74 | 93");
            treeMap[3].Should().Be("38 | 45 | 53 | 55,59 | 69 | 74 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_42()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 42; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("69,90");
            treeMap[1].Should().Be("53,55 | 74 | 93");
            treeMap[2].Should().Be("38 | 53 | 55,59 | 69 | 74 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_43()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 43; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("69,90");
            treeMap[1].Should().Be("55,59 | 74 | 93");
            treeMap[2].Should().Be("38 | 55 | 59 | 69 | 74 | 90 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_44()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 44; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("69");
            treeMap[1].Should().Be("55,59 | 74,93");
            treeMap[2].Should().Be("38 | 55 | 59 | 69 | 74 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_45()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 45; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("69");
            treeMap[1].Should().Be("59 | 74,93");
            treeMap[2].Should().Be("38 | 59 | 69 | 74 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_46()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 46; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("74");
            treeMap[1].Should().Be("69 | 93");
            treeMap[2].Should().Be("59 | 69 | 74 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_47()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 47; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("69,93");
            treeMap[1].Should().Be("59 | 69 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_48()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 48; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("93");
            treeMap[1].Should().Be("69 | 93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_49()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 49; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("93");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        [TestMethod]
        public void Test_Remove_Keys_50()
        {
            var bplustree = new BPlusTree(4);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 50; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("");

            var leaf = bplustree.Root;

            while (!leaf.IsLeaf)
            {
                leaf = leaf.Children[0];
            }

            var allKeys = new List<int>();

            for (var i = 0; i < leaf.KeyCount; i++)
            {
                allKeys.Add(leaf.Keys[i].Value);
            }

            while (leaf.Next != null)
            {
                leaf = leaf.Next;

                for (var i = 0; i < leaf.KeyCount; i++)
                {
                    allKeys.Add(leaf.Keys[i].Value);
                }
            }

            string.Join(",", allKeys.OrderBy(k => k)).Should().Be(string.Join(",", leftKeys.OrderBy(k => k)));
        }

        private string[] GenerateTreeMap(BPlusTreeNode node)
        {
            var treeMap = Enumerable.Range(1, 100).Select(i => string.Empty).ToArray();

            Generate(node, 0, treeMap);

            return treeMap;

            void Generate(BPlusTreeNode node, int level, string[] treeMap)
            {
                if (node == null) return;

                if (treeMap[level] != string.Empty)
                {
                    treeMap[level] += " | ";
                }

                treeMap[level] += string.Join(",", node.Keys).Trim(',');

                foreach (var child in node.Children)
                {
                    Generate(child, level + 1, treeMap);
                }
            }
        }
    }
}
