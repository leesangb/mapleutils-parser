namespace MapleUtils.Parser.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(string name) : base($"`{name}`님을 찾을 수 없습니다.") { }
    }
}
