namespace MapleUtils.Parser.Extensions
{
    public static class ListKeyValueExtensions
    {
        public static IList<(T1, T2)> AddIfNotNull<T1, T2>(this IList<(T1, T2)> list, (T1, T2)? keyValuePair)
        {
            if (keyValuePair != null)
                list.Add(keyValuePair.Value);

            return list;
        }
    }
}
