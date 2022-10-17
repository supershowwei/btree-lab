
var keys = "241,103,249,794,41,537,226,649,136,214,846,72,56,390,645,691,824,766,234,223,311,860,978,111,89,542,119,459,512,785,3,733,727,26,379,920,793,277,602,987,292,481,728,651,624,173,946,895,391,979,970,326,700,422,408,530,90,133,283,480,561,641,483,247,384,123,385,615,540,229,816,185,613,550,305,890,993,493,64,106,744,863,166,91,671,893,945,926,647,24,605,302,503,499,339,484,627,172,594,737".split(",").map(x => parseInt(x));
var treeMap = [];
var btreeTestCaseTemplate = `[TestMethod]
public void Test_Add_Key()
{
    var btree = new BTree(7);

    foreach (var key in Keys)
    {
        btree.Add(key);
    }

    var treeMap = this.GenerateTreeMap(btree.Root);
{{0}}
}
`;
var bplusTreeTestCaseTemplate = `[TestMethod]
public void Test_Add_Key()
{
    var bplustree = new BPlusTree(7);

    foreach (var key in Keys)
    {
        bplustree.Add(key);
    }

    var treeMap = this.GenerateTreeMap(bplustree.Root);
{{0}}

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
`;

var generateTree = function (i) {
    new Promise(function (resolve, reject) {

        $("#AlgorithmSpecificControls input[type='Text']:eq(0)").val(keys[i]);
        $("#AlgorithmSpecificControls input[value='Insert']").trigger("click");

        const loop = function () {
            setTimeout(() => {
                if (!$("#AlgorithmSpecificControls input[value='Insert']").is(":disabled")) {
                    resolve();
                } else {
                    loop();
                }
            }, 100);
        }
        loop();

    }).then(() => {
        i++;
        if (i < keys.length) {
            generateTree(i);
        } else {
            treeMap = [];
            generateMap(currentAlg.treeRoot, 0);

            var assertions = "";

            for (let j = 0; j < treeMap.length; j++) {
                assertions += `
    treeMap[${j}].Should().Be("${treeMap[j]}");`;
            }

            // console.log(btreeTestCaseTemplate.replaceAll("{{0}}", assertions));
            console.log(bplusTreeTestCaseTemplate.replaceAll("{{0}}", assertions));
        }
    });
}

var generateMap = function (node, level) {

    if (!(node)) return;

    if (treeMap[level]) {
        treeMap[level] += " | ";
    } else {
        treeMap[level] = "";
    }

    treeMap[level] += node.keys.filter((k, idx) => idx < node.numKeys).map(k => parseInt(k)).join(",").replace(/(^,)|(,$)/g, "");
    
    for (var i = 0; i <= node.numKeys; i++) {
        generateMap(node.children[i], level + 1);  
    }
}

generateTree(0);
