using MapleUtils.Parser.Models;

namespace MapleUtils.Parser
{
    public interface IMapleUtilsParser
    {
        Task<Character> GetCharacterAsync(string nickName);
    }
}
