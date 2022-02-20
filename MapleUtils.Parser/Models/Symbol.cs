using MapleUtils.Parser.Constants;

namespace MapleUtils.Parser.Models
{
    public record Symbol
    {
        public string Name { get; init; }
        public IDictionary<StatEnum, int> Stat { get; init; }
        public int Level { get; init; }
        public int Experience { get; init; }
        public int RequiredExperience { get; init; }
    }
}
