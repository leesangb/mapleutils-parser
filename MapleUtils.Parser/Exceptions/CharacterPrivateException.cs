namespace MapleUtils.Parser.Exceptions
{
    public class CharacterPrivateException : Exception
    {
        public CharacterPrivateException(string name) : base($"`{name}`님의 정보가 비공개입니다.") { }
    }
}
