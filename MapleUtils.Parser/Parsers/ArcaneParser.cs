using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Extensions;
using MapleUtils.Parser.Models;

namespace MapleUtils.Parser.Parsers
{
    public class ArcaneParser : IArcaneParser
    {
        public Symbol Parse(string text)
        {
            var lines = text.Split("\n").ToList();
            var exp = lines[16].Split("/");
            var symbol = new Symbol
            {
                Name = lines[0].Trim(),
                Level = lines[14].ParseInt(),
                Experience = exp[0].ParseInt(),
                RequiredExperience = exp[1].Split("(")[0].ParseInt(),
                Stat = new Dictionary<StatEnum, int>() { }
            };
            var endIndex = lines.FindLastIndex(l => l.StartsWith("잠재옵션"));
            for (int i = 17; i < endIndex; i += 2)
            {
                if (Stats.StatMapping.TryGetValue(lines[i].Trim(), out var key))
                {
                    symbol.Stat[key] = lines[i + 1].Split("(")[0].ParseInt();
                }
            }
            return symbol;
        }
    }
}
