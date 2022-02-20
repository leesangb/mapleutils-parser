namespace MapleUtils.Parser.Extensions
{
    internal static class StringHelper
    {
        internal static string ToSnakeCase(this string str)
        {
            return string.Concat(
                str.Select(
                    (x, i) => i > 0 && char.IsUpper(x)
                        ? "_" + x
                        : x.ToString()
                        )
                ).ToLower();
        }
        internal static int ParseInt(this string s)
        {
            var num = string.Concat(s.Where(c => char.IsDigit(c)));
            return string.IsNullOrEmpty(num) ? 0 : int.Parse(num);
        }
    }
}
