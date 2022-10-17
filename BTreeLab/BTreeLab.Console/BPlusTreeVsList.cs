using System.Linq;
using BenchmarkDotNet.Attributes;

namespace BTreeLab.Console;

public class BPlusTreeVsList
{
    private BPlusTree bplustree;
    private List<int> keys;
    private List<int> searchKeys;
    private Dictionary<int, int> dict;

    [GlobalSetup]
    public void Setup()
    {
        this.keys = new List<int>();
        this.dict = new Dictionary<int, int>();

        while (this.keys.Count < 10000)
        {
            var key = Random.Shared.Next(1, 100000);

            if (this.dict.ContainsKey(key)) continue;

            this.keys.Add(key);
            this.dict.Add(key, key);
        }

        this.searchKeys = new List<int>();

        while (this.searchKeys.Count < 100)
        {
            var key = Random.Shared.Next(1, 100000);

            if (this.searchKeys.Contains(key)) continue;

            this.searchKeys.Add(key);
        }

        this.bplustree = new BPlusTree(100);

        foreach (var key in this.keys)
        {
            this.bplustree.Add(key);
        }
    }

    //[Benchmark]
    //public void BPlusTreeFind()
    //{
    //    foreach (var searchKey in this.searchKeys)
    //    {
    //        var result = this.bplustree.Find(searchKey);
    //    }
    //}

    //[Benchmark]
    //public void ListFirstOrDefault()
    //{
    //    foreach (var searchKey in this.searchKeys)
    //    {
    //        var result = this.keys.FirstOrDefault(x => x == searchKey);
    //    }
    //}

    //[Benchmark]
    //public void ListSingleOrDefault()
    //{
    //    foreach (var searchKey in this.searchKeys)
    //    {
    //        var result = this.keys.SingleOrDefault(x => x == searchKey);
    //    }
    //}

    //[Benchmark]
    //public void DictionaryTryGetValue()
    //{
    //    foreach (var searchKey in this.searchKeys)
    //    {
    //        this.dict.TryGetValue(searchKey, out var result);
    //    }
    //}

    [Benchmark]
    public void BPlusTreeGreaterThan()
    {
        foreach (var searchKey in this.searchKeys)
        {
            var result = this.bplustree.GreaterThan(searchKey).ToList();
        }
    }

    [Benchmark]
    public void ListWhere()
    {
        foreach (var searchKey in this.searchKeys)
        {
            var result = this.keys.Where(key => key > searchKey).ToList();
        }
    }
}