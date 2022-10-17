using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTreeLab.Tests
{
    [TestClass]
    public class SevenDegreesBTreeTest
    {
        private static readonly List<int> Keys = "241,103,249,794,41,537,226,649,136,214,846,72,56,390,645,691,824,766,234,223,311,860,978,111,89,542,119,459,512,785,3,733,727,26,379,920,793,277,602,987,292,481,728,651,624,173,946,895,391,979,970,326,700,422,408,530,90,133,283,480,561,641,483,247,384,123,385,615,540,229,816,185,613,550,305,890,993,493,64,106,744,863,166,91,671,893,945,926,647,24,605,302,503,499,339,484,627,172,594,737".Split(",").Select(int.Parse).ToList();

        [TestMethod]
        public void Test_Add_Key()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,103,133 | 241,283,311,390 | 493,537,602,645,691 | 794,860,920,978");
            treeMap[2].Should().Be("3,24,26,41 | 64,72,89,90,91 | 106,111,119,123 | 136,166,172,173,185 | 223,226,229,234 | 247,249,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512,530 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785,793 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }
        [TestMethod]
        public void Test_Remove_Keys_1()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 1; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,103,133 | 234,283,311,390 | 493,537,602,645,691 | 794,860,920,978");
            treeMap[2].Should().Be("3,24,26,41 | 64,72,89,90,91 | 106,111,119,123 | 136,166,172,173,185 | 223,226,229 | 247,249,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512,530 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785,793 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_2()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 2; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 234,283,311,390 | 493,537,602,645,691 | 794,860,920,978");
            treeMap[2].Should().Be("3,24,26,41 | 64,72,89,90 | 106,111,119,123 | 136,166,172,173,185 | 223,226,229 | 247,249,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512,530 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785,793 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_3()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 3; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,537,602,645,691 | 794,860,920,978");
            treeMap[2].Should().Be("3,24,26,41 | 64,72,89,90 | 106,111,119,123 | 136,166,172,173,185 | 223,226,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512,530 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785,793 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_4()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 4; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,537,602,645,691 | 793,860,920,978");
            treeMap[2].Should().Be("3,24,26,41 | 64,72,89,90 | 106,111,119,123 | 136,166,172,173,185 | 223,226,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512,530 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_5()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 5; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,537,602,645,691 | 793,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,72,89,90 | 106,111,119,123 | 136,166,172,173,185 | 223,226,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512,530 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_6()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 6; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,530,602,645,691 | 793,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,72,89,90 | 106,111,119,123 | 136,166,172,173,185 | 223,226,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_7()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 7; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,530,602,645,691 | 793,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,72,89,90 | 106,111,119,123 | 136,166,172,173,185 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,649,651,671 | 700,727,728 | 737,744,766,785 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_8()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 8; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,530,602,645,691 | 793,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,72,89,90 | 106,111,119,123 | 136,166,172,173,185 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,651,671 | 700,727,728 | 737,744,766,785 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_9()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 9; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("214,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,530,602,645,691 | 793,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,72,89,90 | 106,111,119,123 | 166,172,173,185 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,651,671 | 700,727,728 | 737,744,766,785 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_10()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 10; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("185,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,530,602,645,691 | 793,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,72,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,651,671 | 700,727,728 | 737,744,766,785 | 816,824,846 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_11()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 11; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("185,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,530,602,645,691 | 785,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,72,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,651,671 | 700,727,728 | 737,744,766 | 793,816,824 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_12()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 12; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("185,459,733");
            treeMap[1].Should().Be("56,91,133 | 283,311,390 | 493,530,602,645,691 | 785,860,920,978");
            treeMap[2].Should().Be("3,24,26 | 64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,651,671 | 700,727,728 | 737,744,766 | 793,816,824 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_13()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 13; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,390 | 493,530,602,645,691 | 785,860,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384,385 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,651,671 | 700,727,728 | 737,744,766 | 793,816,824 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_14()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 14; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,385 | 493,530,602,645,691 | 785,860,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627,641 | 647,651,671 | 700,727,728 | 737,744,766 | 793,816,824 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_15()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 15; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,385 | 493,530,602,641,691 | 785,860,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624,627 | 647,651,671 | 700,727,728 | 737,744,766 | 793,816,824 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_16()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 16; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,385 | 493,530,602,627,671 | 785,860,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,766 | 793,816,824 | 863,890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_17()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 17; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,385 | 493,530,602,627,671 | 785,863,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,766 | 793,816,860 | 890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_18()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 18; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,385 | 493,530,602,627,671 | 863,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,234,247,277 | 292,302,305 | 326,339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816,860 | 890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_19()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 19; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,385 | 493,530,602,627,671 | 863,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 223,229,247,277 | 292,302,305 | 326,339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816,860 | 890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_20()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 20; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,311,385 | 493,530,602,627,671 | 863,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 229,247,277 | 292,302,305 | 326,339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816,860 | 890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_21()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 21; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,326,385 | 493,530,602,627,671 | 863,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816,860 | 890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_22()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 22; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,326,385 | 493,530,602,627,671 | 863,920,978");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946,970 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_23()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 23; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,326,385 | 493,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,111,119,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_24()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 24; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,326,385 | 493,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64,89,90 | 106,119,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_25()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 25; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,326,385 | 493,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64,90 | 106,119,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,542,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_26()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 26; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("91,133,185,283,326,385 | 493,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64,90 | 106,119,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_27()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 27; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("459,733");
            treeMap[1].Should().Be("90,133,185,283,326,385 | 493,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64 | 91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384 | 391,408,422 | 480,481,483,484 | 499,503,512 | 540,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_28()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 28; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,733");
            treeMap[1].Should().Be("90,133,185,283,326 | 493,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64 | 91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384,385,391,408 | 480,481,483,484 | 499,503,512 | 540,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_29()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 29; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,733");
            treeMap[1].Should().Be("90,133,185,283,326 | 484,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64 | 91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,785,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_30()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 30; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,733");
            treeMap[1].Should().Be("90,133,185,283,326 | 484,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("3,24,26,64 | 91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_31()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 31; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,733");
            treeMap[1].Should().Be("90,133,185,283,326 | 484,530,602,627,671 | 863,920,970");
            treeMap[2].Should().Be("24,26,64 | 91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651 | 700,727,728 | 737,744,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_32()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 32; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,728");
            treeMap[1].Should().Be("90,133,185,283,326 | 484,530,602,627 | 863,920,970");
            treeMap[2].Should().Be("24,26,64 | 91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651,671,700,727 | 737,744,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_33()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 33; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,728");
            treeMap[1].Should().Be("90,133,185,283,326 | 484,530,602,627 | 863,920,970");
            treeMap[2].Should().Be("24,26,64 | 91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651,671,700 | 737,744,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_34()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 34; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,728");
            treeMap[1].Should().Be("133,185,283,326 | 484,530,602,627 | 863,920,970");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,379,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651,671,700 | 737,744,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_35()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 35; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,728");
            treeMap[1].Should().Be("133,185,283,326 | 484,530,602,627 | 863,920,970");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651,671,700 | 737,744,793,816 | 890,893,895 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_36()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 36; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,728");
            treeMap[1].Should().Be("133,185,283,326 | 484,530,602,627 | 816,895,970");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651,671,700 | 737,744,793 | 863,890,893 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_37()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 37; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,627");
            treeMap[1].Should().Be("133,185,283,326 | 484,530,602 | 728,895,970");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173 | 229,247,277 | 292,302,305 | 339,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651,671,700 | 737,744,816,863,890,893 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_38()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 38; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,627");
            treeMap[1].Should().Be("133,283,326 | 484,530,602 | 728,895,970");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229,247 | 292,302,305 | 339,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561,594 | 605,613,615,624 | 641,647,651,671,700 | 737,744,816,863,890,893 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_39()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 39; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422,627");
            treeMap[1].Should().Be("133,283,326 | 484,530,594 | 728,895,970");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229,247 | 292,302,305 | 339,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561 | 605,613,615,624 | 641,647,651,671,700 | 737,744,816,863,890,893 | 926,945,946 | 979,987,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_40()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 40; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,283,326 | 484,530,594,627,728,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229,247 | 292,302,305 | 339,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561 | 605,613,615,624 | 641,647,651,671,700 | 737,744,816,863,890,893 | 926,945,946,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_41()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 41; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 484,530,594,627,728,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229 | 283,302,305 | 339,384,385,391,408 | 480,481,483 | 493,499,503 | 540,550,561 | 605,613,615,624 | 641,647,651,671,700 | 737,744,816,863,890,893 | 926,945,946,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_42()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 42; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,728,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229 | 283,302,305 | 339,384,385,391,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615,624 | 641,647,651,671,700 | 737,744,816,863,890,893 | 926,945,946,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_43()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 43; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229 | 283,302,305 | 339,384,385,391,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615,624 | 641,647,651,671 | 737,744,816,863,890,893 | 926,945,946,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_44()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 44; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229 | 283,302,305 | 339,384,385,391,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615,624 | 641,647,671 | 737,744,816,863,890,893 | 926,945,946,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_45()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 45; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,173,185,229 | 283,302,305 | 339,384,385,391,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890,893 | 926,945,946,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_46()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 46; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185,229 | 283,302,305 | 339,384,385,391,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890,893 | 926,945,946,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_47()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 47; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,895");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185,229 | 283,302,305 | 339,384,385,391,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890,893 | 926,945,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_48()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 48; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185,229 | 283,302,305 | 339,384,385,391,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890 | 926,945,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_49()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 49; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185,229 | 283,302,305 | 339,384,385,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890 | 926,945,970,979,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_50()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 50; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185,229 | 283,302,305 | 339,384,385,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890 | 926,945,970,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_51()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 51; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,247,326 | 530,594,627,700,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185,229 | 283,302,305 | 339,384,385,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_52()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 52; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,229,305 | 530,594,627,700,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185 | 247,283,302 | 339,384,385,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 737,744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_53()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 53; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("422");
            treeMap[1].Should().Be("133,229,305 | 530,594,627,737,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185 | 247,283,302 | 339,384,385,408 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_54()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 54; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("408");
            treeMap[1].Should().Be("133,229,305 | 530,594,627,737,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185 | 247,283,302 | 339,384,385 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_55()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 55; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("530");
            treeMap[1].Should().Be("133,229,385 | 594,627,737,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185 | 247,283,302,305,339,384 | 480,483,484,493,499,503 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_56()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 56; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("133,229,385 | 594,627,737,893");
            treeMap[2].Should().Be("24,64,90,91,106,123 | 166,172,185 | 247,283,302,305,339,384 | 480,483,484,493,499 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_57()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 57; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("133,229,385 | 594,627,737,893");
            treeMap[2].Should().Be("24,64,91,106,123 | 166,172,185 | 247,283,302,305,339,384 | 480,483,484,493,499 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_58()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 58; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 594,627,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 247,283,302,305,339,384 | 480,483,484,493,499 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_59()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 59; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 594,627,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 247,302,305,339,384 | 480,483,484,493,499 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_60()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 60; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 594,627,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 247,302,305,339,384 | 483,484,493,499 | 540,550,561 | 605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_61()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 61; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 627,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 247,302,305,339,384 | 483,484,493,499 | 540,550,594,605,613,615 | 641,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_62()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 62; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 615,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 247,302,305,339,384 | 483,484,493,499 | 540,550,594,605,613 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_63()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 63; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 615,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 247,302,305,339,384 | 484,493,499 | 540,550,594,605,613 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_64()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 64; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 615,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 302,305,339,384 | 484,493,499 | 540,550,594,605,613 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_65()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 65; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("123,229,385 | 615,737,893");
            treeMap[2].Should().Be("24,64,91,106 | 166,172,185 | 302,305,339 | 484,493,499 | 540,550,594,605,613 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_66()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 66; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("106,229,385 | 615,737,893");
            treeMap[2].Should().Be("24,64,91 | 166,172,185 | 302,305,339 | 484,493,499 | 540,550,594,605,613 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_67()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 67; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,503,615,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,185,229,302,305 | 484,493,499 | 540,550,594,605,613 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_68()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 68; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,503,613,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,185,229,302,305 | 484,493,499 | 540,550,594,605 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_69()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 69; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,503,613,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,185,229,302,305 | 484,493,499 | 550,594,605 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_70()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 70; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,503,613,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,185,302,305 | 484,493,499 | 550,594,605 | 627,647,671 | 744,816,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_71()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 71; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,503,613,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,185,302,305 | 484,493,499 | 550,594,605 | 627,647,671 | 744,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_72()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 72; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,503,613,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,302,305 | 484,493,499 | 550,594,605 | 627,647,671 | 744,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_73()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 73; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,605,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,302,305 | 484,493,499,503,550,594 | 627,647,671 | 744,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_74()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 74; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,605,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,302,305 | 484,493,499,503,594 | 627,647,671 | 744,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_75()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 75; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,605,737,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,302 | 484,493,499,503,594 | 627,647,671 | 744,863,890 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_76()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 76; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,605,893");
            treeMap[1].Should().Be("24,64,91 | 166,172,302 | 484,493,499,503,594 | 627,647,671,737,744,863 | 926,945,993");
        }

        [TestMethod]
        public void Test_Remove_Keys_77()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 77; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,605,863");
            treeMap[1].Should().Be("24,64,91 | 166,172,302 | 484,493,499,503,594 | 627,647,671,737,744 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_78()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 78; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("106,339,605,863");
            treeMap[1].Should().Be("24,64,91 | 166,172,302 | 484,499,503,594 | 627,647,671,737,744 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_79()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 79; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,605,863");
            treeMap[1].Should().Be("24,91,106,166,172,302 | 484,499,503,594 | 627,647,671,737,744 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_80()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 80; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,605,863");
            treeMap[1].Should().Be("24,91,166,172,302 | 484,499,503,594 | 627,647,671,737,744 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_81()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 81; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,605,863");
            treeMap[1].Should().Be("24,91,166,172,302 | 484,499,503,594 | 627,647,671,737 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_82()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 82; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,605,737");
            treeMap[1].Should().Be("24,91,166,172,302 | 484,499,503,594 | 627,647,671 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_83()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 83; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,605,737");
            treeMap[1].Should().Be("24,91,172,302 | 484,499,503,594 | 627,647,671 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_84()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 84; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,605,737");
            treeMap[1].Should().Be("24,172,302 | 484,499,503,594 | 627,647,671 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_85()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 85; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,594,737");
            treeMap[1].Should().Be("24,172,302 | 484,499,503 | 605,627,647 | 893,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_86()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 86; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,594");
            treeMap[1].Should().Be("24,172,302 | 484,499,503 | 605,627,647,737,926,945");
        }

        [TestMethod]
        public void Test_Remove_Keys_87()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 87; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,594");
            treeMap[1].Should().Be("24,172,302 | 484,499,503 | 605,627,647,737,926");
        }

        [TestMethod]
        public void Test_Remove_Keys_88()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 88; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,594");
            treeMap[1].Should().Be("24,172,302 | 484,499,503 | 605,627,647,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_89()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 89; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("339,594");
            treeMap[1].Should().Be("24,172,302 | 484,499,503 | 605,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_90()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 90; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("594");
            treeMap[1].Should().Be("172,302,339,484,499,503 | 605,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_91()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 91; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("172,302,339,484,499 | 594,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_92()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 92; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("503");
            treeMap[1].Should().Be("172,339,484,499 | 594,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_93()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 93; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("499");
            treeMap[1].Should().Be("172,339,484 | 594,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_94()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 94; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("172,339,484,594,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_95()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 95; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("172,484,594,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_96()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 96; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("172,594,627,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_97()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 97; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("172,594,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_98()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 98; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("594,737");
        }

        [TestMethod]
        public void Test_Remove_Keys_99()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 99; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("737");
        }

        [TestMethod]
        public void Test_Remove_Keys_100()
        {
            var btree = new BTree(7);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var keyIndex = 0;
            for (; keyIndex < 100; keyIndex++)
            {
                btree.Remove(Keys[keyIndex]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("");
        }

        private string[] GenerateTreeMap(BTreeNode node)
        {
            var treeMap = Enumerable.Range(1, 100).Select(i => string.Empty).ToArray();

            Generate(node, 0, treeMap);

            return treeMap;

            void Generate(BTreeNode node, int level, string[] treeMap)
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
