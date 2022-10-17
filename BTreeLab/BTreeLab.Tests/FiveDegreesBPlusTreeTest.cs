using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTreeLab.Tests
{
    [TestClass]
    public class FiveDegreesBPlusTreeTest
    {
        private static readonly List<int> Keys = "241,103,249,794,41,537,226,649,136,214,846,72,56,390,645,691,824,766,234,223,311,860,978,111,89,542,119,459,512,785,3,733,727,26,379,920,793,277,602,987,292,481,728,651,624,173,946,895,391,979,970,326,700,422,408,530,90,133,283,480,561,641,483,247,384,123,385,615,540,229,816,185,613,550,305,890,993,493,64,106,744,863,166,91,671,893,945,926,647,24,605,302,503,499,339,484,627,172,594,737".Split(",").Select(int.Parse).ToList();

        [TestMethod]
        public void Test_Add_Key()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("537");
            treeMap[1].Should().Be("136,241,311,459 | 649,794,920");
            treeMap[2].Should().Be("41,72,103,119 | 173,223 | 277,292 | 379,390 | 481,493,503 | 542,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 41,56,64 | 72,89,90,91 | 103,106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,226,229,234 | 241,247,249 | 277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 537,540 | 542,550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 794,816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("537");
            treeMap[1].Should().Be("136,247,311,459 | 649,794,920");
            treeMap[2].Should().Be("41,72,103,119 | 173,223 | 277,292 | 379,390 | 481,493,503 | 542,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 41,56,64 | 72,89,90,91 | 103,106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,226,229,234 | 247,249 | 277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 537,540 | 542,550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 794,816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("537");
            treeMap[1].Should().Be("136,247,311,459 | 649,794,920");
            treeMap[2].Should().Be("41,72,106,119 | 173,223 | 277,292 | 379,390 | 481,493,503 | 542,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 41,56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,226,229,234 | 247,249 | 277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 537,540 | 542,550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 794,816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("537");
            treeMap[1].Should().Be("136,311,459 | 649,794,920");
            treeMap[2].Should().Be("41,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 542,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 41,56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,226,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 537,540 | 542,550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 794,816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("537");
            treeMap[1].Should().Be("136,311,459 | 649,816,920");
            treeMap[2].Should().Be("41,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 542,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 41,56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,226,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 537,540 | 542,550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("537");
            treeMap[1].Should().Be("136,311,459 | 649,816,920");
            treeMap[2].Should().Be("56,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 542,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,226,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 537,540 | 542,550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("136,311,459 | 649,816,920");
            treeMap[2].Should().Be("56,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,226,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("136,311,459 | 649,816,920");
            treeMap[2].Should().Be("56,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 649,651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("136,311,459 | 651,816,920");
            treeMap[2].Should().Be("56,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 136,166,172 | 173,185,214 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("56,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185,214 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("56,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 846,863 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 846,860 | 863,890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("56,72,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 860,890 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 72,89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("56,89,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 860,890 | 945,978");
            treeMap[3].Should().Be("3,24,26 | 56,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,223,247,292 | 379,390 | 481,493,503 | 550,602,624,641 | 691,733,766 | 860,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 390,391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,223,247,292 | 379,391 | 481,493,503 | 550,602,624,641 | 691,733,766 | 860,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,645,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,223,247,292 | 379,391 | 481,493,503 | 550,602,624,641 | 691,733,766 | 860,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 691,700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,816,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,223,247,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733,766 | 860,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 766,785,793 | 816,824 | 860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,766,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,223,247,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 766,785,793 | 816,860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,785,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,223,247,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229,234 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,785,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,223,247,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 223,229 | 247,277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,311,459 | 651,785,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,229,277,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 311,326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,459 | 651,785,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,229,277,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,860,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,459 | 651,785,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,229,277,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,978");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 978,979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,459 | 651,785,920");
            treeMap[2].Should().Be("26,89,106,119 | 173,229,277,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90,91 | 106,111 | 119,123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,459 | 651,785,920");
            treeMap[2].Should().Be("26,89,91,119 | 173,229,277,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64 | 89,90 | 91,106 | 119,123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,459 | 651,785,920");
            treeMap[2].Should().Be("26,91,119 | 173,229,277,292 | 379,391 | 481,493,503 | 550,602,624,641 | 700,733 | 816,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64,90 | 91,106 | 119,123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,542 | 550,561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,459 | 651,785,920");
            treeMap[2].Should().Be("26,91,119 | 173,229,277,292 | 379,391 | 481,493,503 | 561,602,624,641 | 700,733 | 816,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64,90 | 91,106 | 119,123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,459 | 651,785,920");
            treeMap[2].Should().Be("26,91,123 | 173,229,277,292 | 379,391 | 481,493,503 | 561,602,624,641 | 700,733 | 816,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 459,480 | 481,483,484 | 493,499 | 503,512,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,785,920");
            treeMap[2].Should().Be("26,91,123 | 173,229,277,292 | 379,391 | 483,493,503 | 561,602,624,641 | 700,733 | 816,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,512,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,785,920");
            treeMap[2].Should().Be("26,91,123 | 173,229,277,292 | 379,391 | 483,493,503 | 561,602,624,641 | 700,733 | 816,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 785,793 | 816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,920");
            treeMap[2].Should().Be("26,91,123 | 173,229,277,292 | 379,391 | 483,493,503 | 561,602,624,641 | 700,733,793,890 | 945,979");
            treeMap[3].Should().Be("3,24 | 26,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 793,816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,920");
            treeMap[2].Should().Be("64,91,123 | 173,229,277,292 | 379,391 | 483,493,503 | 561,602,624,641 | 700,733,793,890 | 945,979");
            treeMap[3].Should().Be("24,26 | 64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 733,737,744 | 793,816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,920");
            treeMap[2].Should().Be("64,91,123 | 173,229,277,292 | 379,391 | 483,493,503 | 561,602,624,641 | 700,737,793,890 | 945,979");
            treeMap[3].Should().Be("24,26 | 64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,727,728 | 737,744 | 793,816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,920");
            treeMap[2].Should().Be("64,91,123 | 173,229,277,292 | 379,391 | 483,493,503 | 561,602,624,641 | 700,737,793,890 | 945,979");
            treeMap[3].Should().Be("24,26 | 64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 793,816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,920");
            treeMap[2].Should().Be("91,123 | 173,229,277,292 | 379,391 | 483,493,503 | 561,602,624,641 | 700,737,793,890 | 945,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 379,384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 793,816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,920");
            treeMap[2].Should().Be("91,123 | 173,229,277,292 | 384,391 | 483,493,503 | 561,602,624,641 | 700,737,793,890 | 945,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 793,816,863 | 890,893,895 | 920,926 | 945,946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,277,292 | 384,391 | 483,493,503 | 561,602,624,641 | 700,737,793,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 793,816,863 | 890,893,895 | 926,945 | 946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,277,292 | 384,391 | 483,493,503 | 561,602,624,641 | 700,737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 277,283 | 292,302,305 | 326,339 | 384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,283,302 | 384,391 | 483,493,503 | 561,602,624,641 | 700,737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 283,292 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 602,605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,283,302 | 384,391 | 483,493,503 | 561,605,624,641 | 700,737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 283,292 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,987,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,283,302 | 384,391 | 483,493,503 | 561,605,624,641 | 700,737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247 | 283,292 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,302 | 384,391 | 483,493,503 | 561,605,624,641 | 700,737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,481 | 483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,302 | 384,391 | 493,503 | 561,605,624,641 | 700,737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613,615 | 624,627 | 641,647 | 651,671 | 700,728 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 651,926");
            treeMap[2].Should().Be("91,123 | 173,229,302 | 384,391 | 493,503 | 561,605,624,641 | 737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613,615 | 624,627 | 641,647 | 651,671,700 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 671,926");
            treeMap[2].Should().Be("91,123 | 173,229,302 | 384,391 | 493,503 | 561,605,624,641 | 737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613,615 | 624,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 671,926");
            treeMap[2].Should().Be("91,123 | 173,229,302 | 384,391 | 493,503 | 561,605,615,641 | 737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 173,185 | 229,247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 671,926");
            treeMap[2].Should().Be("91,123 | 185,247,302 | 384,391 | 493,503 | 561,605,615,641 | 737,816,890 | 946,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893,895 | 926,945 | 946,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 671,890");
            treeMap[2].Should().Be("91,123 | 185,247,302 | 384,391 | 493,503 | 561,605,615,641 | 737,816 | 926,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893,895 | 926,945,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 671,890");
            treeMap[2].Should().Be("91,123 | 185,247,302 | 384,391 | 493,503 | 561,605,615,641 | 737,816 | 926,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 326,339 | 384,385 | 391,408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893 | 926,945,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 671,890");
            treeMap[2].Should().Be("91,123 | 185,247,302 | 384,408 | 493,503 | 561,605,615,641 | 737,816 | 926,979");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 326,339 | 384,385 | 408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893 | 926,945,970 | 979,993");

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
            var bplustree = new BPlusTree(5);

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

            treeMap[0].Should().Be("540");
            treeMap[1].Should().Be("166,326,480 | 671,890");
            treeMap[2].Should().Be("91,123 | 185,247,302 | 384,408 | 493,503 | 561,605,615,641 | 737,816 | 926,970");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 326,339 | 384,385 | 408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893 | 926,945 | 970,993");

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
        public void Test_Remove_Keys_51()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 51; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("480");
            treeMap[1].Should().Be("166,326 | 540,671");
            treeMap[2].Should().Be("91,123 | 185,247,302 | 384,408 | 493,503 | 561,605,615,641 | 737,816,890,926");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 326,339 | 384,385 | 408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_52()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 52; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("480");
            treeMap[1].Should().Be("166,302 | 540,671");
            treeMap[2].Should().Be("91,123 | 185,247 | 339,408 | 493,503 | 561,605,615,641 | 737,816,890,926");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 339,384,385 | 408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,700 | 737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_53()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 53; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("480");
            treeMap[1].Should().Be("166,302 | 540,671");
            treeMap[2].Should().Be("91,123 | 185,247 | 339,408 | 493,503 | 561,605,615,641 | 816,890,926");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 339,384,385 | 408,422 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_54()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 54; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("480");
            treeMap[1].Should().Be("166,302 | 540,671");
            treeMap[2].Should().Be("91,123 | 185,247 | 339,385 | 493,503 | 561,605,615,641 | 816,890,926");
            treeMap[3].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 339,384 | 385,408 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_55()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 55; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("166,480,540,671");
            treeMap[1].Should().Be("91,123 | 185,247,302,339 | 493,503 | 561,605,615,641 | 816,890,926");
            treeMap[2].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 339,384,385 | 480,483,484 | 493,499 | 503,530 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_56()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 56; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("166,339,540,671");
            treeMap[1].Should().Be("91,123 | 185,247,302 | 480,493 | 561,605,615,641 | 816,890,926");
            treeMap[2].Should().Be("24,64,90 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 339,384,385 | 480,483,484 | 493,499,503 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_57()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 57; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("166,339,540,671");
            treeMap[1].Should().Be("91,123 | 185,247,302 | 480,493 | 561,605,615,641 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 123,133 | 166,172 | 185,229 | 247,283 | 302,305 | 339,384,385 | 480,483,484 | 493,499,503 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_58()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 58; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("185,339,540,671");
            treeMap[1].Should().Be("91,166 | 247,302 | 480,493 | 561,605,615,641 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229 | 247,283 | 302,305 | 339,384,385 | 480,483,484 | 493,499,503 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_59()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 59; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,540,671");
            treeMap[1].Should().Be("91,166,185,302 | 480,493 | 561,605,615,641 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229,247 | 302,305 | 339,384,385 | 480,483,484 | 493,499,503 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_60()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 60; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,540,671");
            treeMap[1].Should().Be("91,166,185,302 | 483,493 | 561,605,615,641 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229,247 | 302,305 | 339,384,385 | 483,484 | 493,499,503 | 540,550 | 561,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_61()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 61; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,540,671");
            treeMap[1].Should().Be("91,166,185,302 | 483,493 | 605,615,641 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229,247 | 302,305 | 339,384,385 | 483,484 | 493,499,503 | 540,550,594 | 605,613 | 615,627 | 641,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_62()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 62; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,540,671");
            treeMap[1].Should().Be("91,166,185,302 | 483,493 | 605,615 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229,247 | 302,305 | 339,384,385 | 483,484 | 493,499,503 | 540,550,594 | 605,613 | 615,627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_63()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 63; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,540,671");
            treeMap[1].Should().Be("91,166,185,302 | 385,493 | 605,615 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229,247 | 302,305 | 339,384 | 385,484 | 493,499,503 | 540,550,594 | 605,613 | 615,627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_64()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 64; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,540,671");
            treeMap[1].Should().Be("91,166,185,302 | 385,493 | 605,615 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229 | 302,305 | 339,384 | 385,484 | 493,499,503 | 540,550,594 | 605,613 | 615,627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_65()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 65; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,540,671");
            treeMap[1].Should().Be("91,166,185 | 339,493 | 605,615 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106,123 | 166,172 | 185,229 | 302,305 | 339,385,484 | 493,499,503 | 540,550,594 | 605,613 | 615,627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_66()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 66; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,540,671");
            treeMap[1].Should().Be("91,166,185 | 339,493 | 605,615 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 185,229 | 302,305 | 339,385,484 | 493,499,503 | 540,550,594 | 605,613 | 615,627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_67()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 67; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,540,671");
            treeMap[1].Should().Be("91,166,185 | 339,493 | 605,615 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 185,229 | 302,305 | 339,484 | 493,499,503 | 540,550,594 | 605,613 | 615,627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_68()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 68; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,540,671");
            treeMap[1].Should().Be("91,166,185 | 339,493 | 605,627 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 185,229 | 302,305 | 339,484 | 493,499,503 | 540,550,594 | 605,613 | 627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_69()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 69; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,550,671");
            treeMap[1].Should().Be("91,166,185 | 339,493 | 605,627 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 185,229 | 302,305 | 339,484 | 493,499,503 | 550,594 | 605,613 | 627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_70()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 70; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,550,671");
            treeMap[1].Should().Be("91,166 | 339,493 | 605,627 | 816,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172,185 | 302,305 | 339,484 | 493,499,503 | 550,594 | 605,613 | 627,647 | 671,737,744 | 816,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_71()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 71; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,550,671");
            treeMap[1].Should().Be("91,166 | 339,493 | 605,627 | 744,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172,185 | 302,305 | 339,484 | 493,499,503 | 550,594 | 605,613 | 627,647 | 671,737 | 744,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_72()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 72; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,550,671");
            treeMap[1].Should().Be("91,166 | 339,493 | 605,627 | 744,890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 302,305 | 339,484 | 493,499,503 | 550,594 | 605,613 | 627,647 | 671,737 | 744,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_73()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 73; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,550,744");
            treeMap[1].Should().Be("91,166 | 339,493 | 627,671 | 890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 302,305 | 339,484 | 493,499,503 | 550,594,605 | 627,647 | 671,737 | 744,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_74()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 74; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("302,594,744");
            treeMap[1].Should().Be("91,166 | 339,493 | 627,671 | 890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 302,305 | 339,484 | 493,499,503 | 594,605 | 627,647 | 671,737 | 744,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_75()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 75; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594,744");
            treeMap[1].Should().Be("91,166,302,493 | 627,671 | 890,926");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 302,339,484 | 493,499,503 | 594,605 | 627,647 | 671,737 | 744,863 | 890,893 | 926,945,993");

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
        public void Test_Remove_Keys_76()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 76; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594,744");
            treeMap[1].Should().Be("91,166,302,493 | 627,671 | 893,945");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 302,339,484 | 493,499,503 | 594,605 | 627,647 | 671,737 | 744,863 | 893,926 | 945,993");

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
        public void Test_Remove_Keys_77()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 77; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("91,166,302,493 | 627,671,744,893");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 302,339,484 | 493,499,503 | 594,605 | 627,647 | 671,737 | 744,863 | 893,926,945");

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
        public void Test_Remove_Keys_78()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 78; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("91,166,302,499 | 627,671,744,893");
            treeMap[2].Should().Be("24,64 | 91,106 | 166,172 | 302,339,484 | 499,503 | 594,605 | 627,647 | 671,737 | 744,863 | 893,926,945");

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
        public void Test_Remove_Keys_79()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 79; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("166,302,499 | 627,671,744,893");
            treeMap[2].Should().Be("24,91,106 | 166,172 | 302,339,484 | 499,503 | 594,605 | 627,647 | 671,737 | 744,863 | 893,926,945");

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
        public void Test_Remove_Keys_80()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 80; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("166,302,499 | 627,671,744,893");
            treeMap[2].Should().Be("24,91 | 166,172 | 302,339,484 | 499,503 | 594,605 | 627,647 | 671,737 | 744,863 | 893,926,945");

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
        public void Test_Remove_Keys_81()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 81; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("166,302,499 | 627,671,863,926");
            treeMap[2].Should().Be("24,91 | 166,172 | 302,339,484 | 499,503 | 594,605 | 627,647 | 671,737 | 863,893 | 926,945");

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
        public void Test_Remove_Keys_82()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 82; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("166,302,499 | 627,671,926");
            treeMap[2].Should().Be("24,91 | 166,172 | 302,339,484 | 499,503 | 594,605 | 627,647 | 671,737,893 | 926,945");

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
        public void Test_Remove_Keys_83()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 83; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("172,339,499 | 627,671,926");
            treeMap[2].Should().Be("24,91 | 172,302 | 339,484 | 499,503 | 594,605 | 627,647 | 671,737,893 | 926,945");

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
        public void Test_Remove_Keys_84()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 84; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("339,499 | 627,671,926");
            treeMap[2].Should().Be("24,172,302 | 339,484 | 499,503 | 594,605 | 627,647 | 671,737,893 | 926,945");

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
        public void Test_Remove_Keys_85()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 85; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("339,499 | 627,737,926");
            treeMap[2].Should().Be("24,172,302 | 339,484 | 499,503 | 594,605 | 627,647 | 737,893 | 926,945");

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
        public void Test_Remove_Keys_86()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 86; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("339,499 | 627,926");
            treeMap[2].Should().Be("24,172,302 | 339,484 | 499,503 | 594,605 | 627,647,737 | 926,945");

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
        public void Test_Remove_Keys_87()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 87; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("339,499 | 627,737");
            treeMap[2].Should().Be("24,172,302 | 339,484 | 499,503 | 594,605 | 627,647 | 737,926");

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
        public void Test_Remove_Keys_88()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 88; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,499,594,627");
            treeMap[1].Should().Be("24,172,302 | 339,484 | 499,503 | 594,605 | 627,647,737");

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
        public void Test_Remove_Keys_89()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 89; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,499,594,627");
            treeMap[1].Should().Be("24,172,302 | 339,484 | 499,503 | 594,605 | 627,737");

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
        public void Test_Remove_Keys_90()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 90; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,499,594,627");
            treeMap[1].Should().Be("172,302 | 339,484 | 499,503 | 594,605 | 627,737");

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
        public void Test_Remove_Keys_91()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 91; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("339,499,627");
            treeMap[1].Should().Be("172,302 | 339,484 | 499,503,594 | 627,737");

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
        public void Test_Remove_Keys_92()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 92; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("499,627");
            treeMap[1].Should().Be("172,339,484 | 499,503,594 | 627,737");

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
        public void Test_Remove_Keys_93()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 93; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("499,627");
            treeMap[1].Should().Be("172,339,484 | 499,594 | 627,737");

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
        public void Test_Remove_Keys_94()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 94; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("484,627");
            treeMap[1].Should().Be("172,339 | 484,594 | 627,737");

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
        public void Test_Remove_Keys_95()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 95; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("627");
            treeMap[1].Should().Be("172,484,594 | 627,737");

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
        public void Test_Remove_Keys_96()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 96; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("627");
            treeMap[1].Should().Be("172,594 | 627,737");

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
        public void Test_Remove_Keys_97()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 97; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("172,594,737");

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
        public void Test_Remove_Keys_98()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 98; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("594,737");

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
        public void Test_Remove_Keys_99()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 99; keyIndex++)
            {
                bplustree.Remove(Keys[keyIndex]);
            }

            var leftKeys = Keys.Where((k, index) => index >= keyIndex).ToList();

            var treeMap = this.GenerateTreeMap(bplustree.Root);

            treeMap[0].Should().Be("737");

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
        public void Test_Remove_Keys_100()
        {
            var bplustree = new BPlusTree(5);

            foreach (var key in Keys)
            {
                bplustree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 100; keyIndex++)
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
