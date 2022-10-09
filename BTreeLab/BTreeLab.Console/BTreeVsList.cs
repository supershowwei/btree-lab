using BenchmarkDotNet.Attributes;

namespace BTreeLab.Console;

public class BTreeVsList
{
    private BTree btree;
    private List<int> keys;
    private List<int> searchKeys;
    private Dictionary<int, int> dict;

    [GlobalSetup]
    public void Setup()
    {
        this.keys = new List<int>();
        this.dict = new Dictionary<int, int>();

        while (this.keys.Count < 1000)
        {
            var key = Random.Shared.Next(1, 10000);

            if (this.keys.Contains(key)) continue;

            this.keys.Add(key);
            this.dict.Add(key, key);
        }

        this.searchKeys = new List<int>();

        while (this.searchKeys.Count < 100)
        {
            var key = Random.Shared.Next(1, 10000);

            if (this.searchKeys.Contains(key)) continue;

            this.searchKeys.Add(key);
        }

        this.btree = new BTree(7);

        foreach (var key in this.keys)
        {
            this.btree.Add(key);
        }
    }

    [Benchmark]
    public void BTreeFind()
    {
        foreach (var searchKey in this.searchKeys)
        {
            var result = this.btree.Find(searchKey);
        }
    }

    [Benchmark]
    public void ListFirstOrDefault()
    {
        foreach (var searchKey in this.searchKeys)
        {
            var result = this.keys.FirstOrDefault(x => x == searchKey);
        }
    }

    [Benchmark]
    public void ListSingleOrDefault()
    {
        foreach (var searchKey in this.searchKeys)
        {
            var result = this.keys.SingleOrDefault(x => x == searchKey);
        }
    }

    //[Benchmark]
    //public void DictionaryTryGetValue()
    //{
    //    foreach (var searchKey in this.searchKeys)
    //    {
    //        this.dict.TryGetValue(searchKey, out var result);
    //    }
    //}

    //[Benchmark]
    //public void ListWhere()
    //{
    //    foreach (var searchKey in this.searchKeys)
    //    {
    //        var result = this.keys.Where(key => key > searchKey).ToList();
    //    }
    //}

    //[Benchmark]
    //public void DictionaryWhere()
    //{
    //    foreach (var searchKey in this.searchKeys)
    //    {
    //        var result = this.dict.Keys.Where(key => key > searchKey).ToList();
    //    }
    //}
}