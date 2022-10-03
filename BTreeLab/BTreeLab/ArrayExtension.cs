namespace BTreeLab;

internal static class ArrayExtension
{
    public static T RemoveAt<T>(this T[] me, int index)
    {
        var item = me[index];

        me[index] = default;

        return item;
    }
}