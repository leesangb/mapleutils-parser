namespace MapleUtils.Parser.Parsers
{
    public interface IParser<T>
    {
        T Parse(string text);
    }
}
