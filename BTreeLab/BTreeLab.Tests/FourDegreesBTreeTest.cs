using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTreeLab.Tests
{
    [TestClass]
    public class FourDegreesBTreeTest
    {
        private static readonly List<int> Keys = "21,73,23,15,66,72,34,1,79,64,95,35,8,2,84,26,52,97,51,88,80,36,24,62,94,89,76,75,70,63,49,91,33,43,27,92,9,25,78,65,3,45,53,90,55,38,74,59,69,93".Split(",").Select(int.Parse).ToList();

        [TestMethod]
        public void Test_Add_Key()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("34,66");
            treeMap[1].Should().Be("21 | 43 | 76,89");
            treeMap[2].Should().Be("2,8 | 24,26 | 36 | 51,53,62 | 73 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3 | 9,15 | 23 | 25 | 27,33 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64,65 | 69,70,72 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_1()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 1; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("34,66");
            treeMap[1].Should().Be("15 | 43 | 76,89");
            treeMap[2].Should().Be("2,8 | 24,26 | 36 | 51,53,62 | 73 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3 | 9 | 23 | 25 | 27,33 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64,65 | 69,70,72 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_2()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 2; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("34,66");
            treeMap[1].Should().Be("15 | 43 | 76,89");
            treeMap[2].Should().Be("2,8 | 24,26 | 36 | 51,53,62 | 72 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3 | 9 | 23 | 25 | 27,33 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64,65 | 69,70 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_3()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 3; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("34,66");
            treeMap[1].Should().Be("15 | 43 | 76,89");
            treeMap[2].Should().Be("2,8 | 26 | 36 | 51,53,62 | 72 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3 | 9 | 24,25 | 27,33 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64,65 | 69,70 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_4()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 4; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("34,66");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("2 | 26 | 36 | 51,53,62 | 72 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3,8 | 24,25 | 27,33 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64,65 | 69,70 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_5()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 5; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("34,65");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("2 | 26 | 36 | 51,53,62 | 72 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3,8 | 24,25 | 27,33 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64 | 69,70 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_6()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 6; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("34,65");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("2 | 26 | 36 | 51,53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3,8 | 24,25 | 27,33 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64 | 69 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_7()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 7; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("33,65");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("2 | 26 | 36 | 51,53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("1 | 3,8 | 24,25 | 27 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64 | 69 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_8()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 8; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("33,65");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("3 | 26 | 36 | 51,53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("2 | 8 | 24,25 | 27 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64 | 69 | 74,75 | 78,79,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_9()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 9; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("33,65");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("3 | 26 | 36 | 51,53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("2 | 8 | 24,25 | 27 | 35 | 38 | 45,49 | 52 | 55,59 | 63,64 | 69 | 74,75 | 78,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_10()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 10; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("33,65");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("3 | 26 | 36 | 51,53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("2 | 8 | 24,25 | 27 | 35 | 38 | 45,49 | 52 | 55,59 | 63 | 69 | 74,75 | 78,80 | 88 | 90 | 92,93 | 95,97");
        }

        [TestMethod]
        public void Test_Remove_Keys_11()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 11; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("33,65");
            treeMap[1].Should().Be("9 | 43 | 76,89");
            treeMap[2].Should().Be("3 | 26 | 36 | 51,53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("2 | 8 | 24,25 | 27 | 35 | 38 | 45,49 | 52 | 55,59 | 63 | 69 | 74,75 | 78,80 | 88 | 90 | 92,93 | 97");
        }

        [TestMethod]
        public void Test_Remove_Keys_12()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 12; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("33,65");
            treeMap[1].Should().Be("9 | 51 | 76,89");
            treeMap[2].Should().Be("3 | 26 | 43 | 53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("2 | 8 | 24,25 | 27 | 36,38 | 45,49 | 52 | 55,59 | 63 | 69 | 74,75 | 78,80 | 88 | 90 | 92,93 | 97");
        }

        [TestMethod]
        public void Test_Remove_Keys_13()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 13; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,51 | 76,89");
            treeMap[2].Should().Be("9,26 | 43 | 53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("2,3 | 24,25 | 27 | 36,38 | 45,49 | 52 | 55,59 | 63 | 69 | 74,75 | 78,80 | 88 | 90 | 92,93 | 97");
        }

        [TestMethod]
        public void Test_Remove_Keys_14()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 14; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,51 | 76,89");
            treeMap[2].Should().Be("9,26 | 43 | 53,62 | 70 | 84 | 91,94");
            treeMap[3].Should().Be("3 | 24,25 | 27 | 36,38 | 45,49 | 52 | 55,59 | 63 | 69 | 74,75 | 78,80 | 88 | 90 | 92,93 | 97");
        }

        [TestMethod]
        public void Test_Remove_Keys_15()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 15; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,51 | 76,89");
            treeMap[2].Should().Be("9,26 | 43 | 53,62 | 70 | 80 | 91,94");
            treeMap[3].Should().Be("3 | 24,25 | 27 | 36,38 | 45,49 | 52 | 55,59 | 63 | 69 | 74,75 | 78 | 88 | 90 | 92,93 | 97");
        }

        [TestMethod]
        public void Test_Remove_Keys_16()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 16; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,51 | 76,89");
            treeMap[2].Should().Be("9,25 | 43 | 53,62 | 70 | 80 | 91,94");
            treeMap[3].Should().Be("3 | 24 | 27 | 36,38 | 45,49 | 52 | 55,59 | 63 | 69 | 74,75 | 78 | 88 | 90 | 92,93 | 97");
        }

        [TestMethod]
        public void Test_Remove_Keys_17()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 17; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,51 | 76,89");
            treeMap[2].Should().Be("9,25 | 43 | 55,62 | 70 | 80 | 91,94");
            treeMap[3].Should().Be("3 | 24 | 27 | 36,38 | 45,49 | 53 | 59 | 63 | 69 | 74,75 | 78 | 88 | 90 | 92,93 | 97");
        }

        [TestMethod]
        public void Test_Remove_Keys_18()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 18; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,51 | 76,89");
            treeMap[2].Should().Be("9,25 | 43 | 55,62 | 70 | 80 | 91,93");
            treeMap[3].Should().Be("3 | 24 | 27 | 36,38 | 45,49 | 53 | 59 | 63 | 69 | 74,75 | 78 | 88 | 90 | 92 | 94");
        }

        [TestMethod]
        public void Test_Remove_Keys_19()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 19; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76,89");
            treeMap[2].Should().Be("9,25 | 43 | 55,62 | 70 | 80 | 91,93");
            treeMap[3].Should().Be("3 | 24 | 27 | 36,38 | 45 | 53 | 59 | 63 | 69 | 74,75 | 78 | 88 | 90 | 92 | 94");
        }

        [TestMethod]
        public void Test_Remove_Keys_20()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 20; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76,91");
            treeMap[2].Should().Be("9,25 | 43 | 55,62 | 70 | 89 | 93");
            treeMap[3].Should().Be("3 | 24 | 27 | 36,38 | 45 | 53 | 59 | 63 | 69 | 74,75 | 78,80 | 90 | 92 | 94");
        }

        [TestMethod]
        public void Test_Remove_Keys_21()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 21; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76,91");
            treeMap[2].Should().Be("9,25 | 43 | 55,62 | 70 | 89 | 93");
            treeMap[3].Should().Be("3 | 24 | 27 | 36,38 | 45 | 53 | 59 | 63 | 69 | 74,75 | 78 | 90 | 92 | 94");
        }

        [TestMethod]
        public void Test_Remove_Keys_22()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 22; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76,91");
            treeMap[2].Should().Be("9,25 | 43 | 55,62 | 70 | 89 | 93");
            treeMap[3].Should().Be("3 | 24 | 27 | 38 | 45 | 53 | 59 | 63 | 69 | 74,75 | 78 | 90 | 92 | 94");
        }

        [TestMethod]
        public void Test_Remove_Keys_23()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 23; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76,91");
            treeMap[2].Should().Be("25 | 43 | 55,62 | 70 | 89 | 93");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53 | 59 | 63 | 69 | 74,75 | 78 | 90 | 92 | 94");
        }

        [TestMethod]
        public void Test_Remove_Keys_24()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 24; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76,91");
            treeMap[2].Should().Be("25 | 43 | 59 | 70 | 89 | 93");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53,55 | 63 | 69 | 74,75 | 78 | 90 | 92 | 94");
        }

        [TestMethod]
        public void Test_Remove_Keys_25()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 25; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76");
            treeMap[2].Should().Be("25 | 43 | 59 | 70 | 89,91");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53,55 | 63 | 69 | 74,75 | 78 | 90 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_26()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 26; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 76");
            treeMap[2].Should().Be("25 | 43 | 59 | 70 | 91");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53,55 | 63 | 69 | 74,75 | 78,90 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_27()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 27; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("33,49 | 75");
            treeMap[2].Should().Be("25 | 43 | 59 | 70 | 91");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53,55 | 63 | 69 | 74 | 78,90 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_28()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 28; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("49");
            treeMap[1].Should().Be("33 | 65");
            treeMap[2].Should().Be("25 | 43 | 59 | 74,91");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53,55 | 63 | 69,70 | 78,90 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_29()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 29; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("49");
            treeMap[1].Should().Be("33 | 65");
            treeMap[2].Should().Be("25 | 43 | 59 | 74,91");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53,55 | 63 | 69 | 78,90 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_30()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 30; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("49");
            treeMap[1].Should().Be("33 | 65");
            treeMap[2].Should().Be("25 | 43 | 55 | 74,91");
            treeMap[3].Should().Be("3,9 | 27 | 38 | 45 | 53 | 59 | 69 | 78,90 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_31()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 31; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("45,65");
            treeMap[1].Should().Be("25,33 | 55 | 74,91");
            treeMap[2].Should().Be("3,9 | 27 | 38,43 | 53 | 59 | 69 | 78,90 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_32()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 32; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("45,65");
            treeMap[1].Should().Be("25,33 | 55 | 74,90");
            treeMap[2].Should().Be("3,9 | 27 | 38,43 | 53 | 59 | 69 | 78 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_33()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 33; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("45,65");
            treeMap[1].Should().Be("9,27 | 55 | 74,90");
            treeMap[2].Should().Be("3 | 25 | 38,43 | 53 | 59 | 69 | 78 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_34()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 34; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("45,65");
            treeMap[1].Should().Be("9,27 | 55 | 74,90");
            treeMap[2].Should().Be("3 | 25 | 38 | 53 | 59 | 69 | 78 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_35()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 35; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("45,65");
            treeMap[1].Should().Be("25 | 55 | 74,90");
            treeMap[2].Should().Be("3,9 | 38 | 53 | 59 | 69 | 78 | 92,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_36()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 36; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("45,65");
            treeMap[1].Should().Be("25 | 55 | 74,90");
            treeMap[2].Should().Be("3,9 | 38 | 53 | 59 | 69 | 78 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_37()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 37; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("45,65");
            treeMap[1].Should().Be("25 | 55 | 74,90");
            treeMap[2].Should().Be("3 | 38 | 53 | 59 | 69 | 78 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_38()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 38; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("45,55 | 74,90");
            treeMap[2].Should().Be("3,38 | 53 | 59 | 69 | 78 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_39()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 39; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("65");
            treeMap[1].Should().Be("45,55 | 90");
            treeMap[2].Should().Be("3,38 | 53 | 59 | 69,74 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_40()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 40; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("59");
            treeMap[1].Should().Be("45 | 90");
            treeMap[2].Should().Be("3,38 | 53,55 | 69,74 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_41()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 41; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("59");
            treeMap[1].Should().Be("45 | 90");
            treeMap[2].Should().Be("38 | 53,55 | 69,74 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_42()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 42; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("59");
            treeMap[1].Should().Be("53 | 90");
            treeMap[2].Should().Be("38 | 55 | 69,74 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_43()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 43; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("59,90");
            treeMap[1].Should().Be("38,55 | 69,74 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_44()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 44; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("59,74");
            treeMap[1].Should().Be("38,55 | 69 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_45()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 45; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("59,74");
            treeMap[1].Should().Be("38 | 69 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_46()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 46; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("74");
            treeMap[1].Should().Be("59,69 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_47()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 47; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("69");
            treeMap[1].Should().Be("59 | 93");
        }

        [TestMethod]
        public void Test_Remove_Keys_48()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 48; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("69,93");
        }

        [TestMethod]
        public void Test_Remove_Keys_49()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 49; i++)
            {
                btree.Remove(Keys[i]);
            }

            var treeMap = this.GenerateTreeMap(btree.Root);

            treeMap[0].Should().Be("93");
        }

        [TestMethod]
        public void Test_Remove_Keys_50()
        {
            var btree = new BTree(4);

            foreach (var key in Keys)
            {
                btree.Add(key);
            }

            for (var i = 0; i < 50; i++)
            {
                btree.Remove(Keys[i]);
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
