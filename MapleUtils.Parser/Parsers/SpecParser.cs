using MapleUtils.Parser.Extensions;
using MapleUtils.Parser.Models;

namespace MapleUtils.Parser.Parsers
{
    public class SpecParser : ISpecParser
    {
        private const int ABILITY_START_LINE_INDEX = 37;
        private readonly IAbilitiesParser AbilitiesParser;
        private readonly IHyperStatsParser HyperStatsParser;

        public SpecParser(IAbilitiesParser abilitiesParser, IHyperStatsParser hyperStatsParser)
        {
            AbilitiesParser = abilitiesParser;
            HyperStatsParser = hyperStatsParser;
        }


        public Spec Parse(string text)
        {
            var lines = text.Replace("\n", "\t").Split("\t").Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
            var statAtk = lines[1].Split(" ~ ");
            var hyperStatIndex = lines.LastIndexOf("하이퍼스탯");
            var abilityLines = string.Join("\n", lines.Skip(ABILITY_START_LINE_INDEX).Take(hyperStatIndex - ABILITY_START_LINE_INDEX));
            var hyperStatLines = string.Join("\n", lines.Skip(hyperStatIndex + 1));

            var spec = new Spec()
            {
                StatAtkLow = statAtk[0].ParseInt(),
                StatAtkHigh = statAtk[1].ParseInt(),
                Hp = lines[3].ParseInt(),
                Mp = lines[5].ParseInt(),
                Str = lines[7].ParseInt(),
                Dex = lines[9].ParseInt(),
                Int = lines[11].ParseInt(),
                Luk = lines[13].ParseInt(),
                CritDmg = lines[15].ParseInt(),
                BossDmg = lines[17].ParseInt(),
                IgnoreDef = lines[19].ParseInt(),
                // Dmg = ??,
                Resistance = lines[21].ParseInt(),
                Stance = lines[23].ParseInt(),
                Def = lines[25].ParseInt(),
                Speed = lines[27].ParseInt(),
                Jump = lines[29].ParseInt(),
                StarForce = lines[31].ParseInt(),
                ArcaneForce = lines[35].ParseInt(),
                // AuthenticForce = ??
                Abilities = AbilitiesParser.Parse(abilityLines),
                Hypers = HyperStatsParser.Parse(hyperStatLines),
            };

            return spec;
        }
    }
}
