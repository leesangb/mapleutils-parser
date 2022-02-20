namespace MapleUtils.Parser.Extensions
{
    internal static class ReadOnlyListExtensions
    {
        internal static int LastIndexOf<T>(this IReadOnlyCollection<T> list, T element) where T : class
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
