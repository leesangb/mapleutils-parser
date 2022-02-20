using MapleUtils.Parser.Constants;

namespace MapleUtils.Parser.Models
{
    public record Spec
    {
        public int StatAtkLow { get; init; }
        public int StatAtkHigh { get; init; }
        public int Hp { get; init; }
        public int Mp { get; init; }
        public int Str { get; init; }
        public int Dex { get; init; }
        public int Int { get; init; }
        public int Luk { get; init; }
        public double CritDmg { get; init; }
        public int BossDmg { get; init; }
        public double IgnoreDef { get; init; }
        public int Dmg { get; init; }
        public int Resistance { get; init; }
        public int Stance { get; init; }
        public int Def { get; init; }
        public int Speed { get; init; }
        public int Jump { get; init; }
        public int StarForce { get; init; }
        public int ArcaneForce { get; init; }
        public int AuthenticForce { get; init; }
        public IDictionary<string, int> Abilities { get; init; }
        public IDictionary<StatEnum, int> Hypers { get; init; }
    }
}
