using MapleUtils.Parser.Models;

namespace MapleUtils.Parser
{
    public interface IMapleUtilsParser
    {
        Task<Character> GetCharacter(string nickName);
    }
}
