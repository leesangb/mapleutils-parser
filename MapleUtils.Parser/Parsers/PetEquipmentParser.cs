using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Extensions;
using MapleUtils.Parser.Models;
using System.Text.RegularExpressions;

namespace MapleUtils.Parser.Parsers
{
    public class PetEquipmentParser : IPetEquipmentParser
    {
        private (string name, int upgrade) ParseEquipmentName(string line)
        {
            var name = line;
            var upgrade = "";

            var upgradeIndex = name.LastIndexOf("(+");
            if (upgradeIndex > 0)
            {
                name = line.Substring(0, upgradeIndex - 1);
                upgrade = line.Substring(upgradeIndex, line.LastIndexOf(")") - upgradeIndex);
            }

            return (name.Trim(), upgrade.ParseInt());
        }

        
        private (int baseStat, int flameStat, int scrollStat) ParseStat(string line)
        {
            var parenthesisIndex = line.IndexOf("(");
            if (parenthesisIndex < 0)
                return (line.ParseInt(), 0, 0);

            var stats = line.Substring(parenthesisIndex + 1, line.Length - 2 - parenthesisIndex)
                .Split(" + ")
                .Select(s => s.ParseInt())
                .ToArray();
            if (stats.Length == 0)
                return (0, 0, 0);
            if (stats.Length == 1)
                return (stats[0], 0, 0);
            if (stats.Length == 2)
                return (stats[0], stats[1], 0);
            return (stats[0], stats[1], stats[2]);
        }

        public CashEquipment Parse(string text)
        {
            var lines = text.Split("\n").ToList();
            var (name, upgrade) = ParseEquipmentName(lines[0]);

            var categoryIndex = lines.FindIndex(l => l.StartsWith("장비분류"));
            var category = lines[categoryIndex].Split(" | ")[1];
            category = Regex.Replace(category, " \\(.*", "");
            var image = lines.Last();

            var statStartIndex = categoryIndex + 1;
            var statEndIndex = lines.FindLastIndex(l => l.StartsWith("업그레이드") || l.StartsWith("잠재옵션") || l.StartsWith("가위 사용 가능"));
            var baseStats = new Dictionary<StatEnum, int>();
            var scrollStats = new Dictionary<StatEnum, int>();

            for (var i = statStartIndex; i < statEndIndex; i += 2)
            {
                var option = lines[i];
                var statValue = lines[i + 1];
                StatEnum key;

                if (Stats.StatMapping.TryGetValue(option, out key))
                {
                    var (bs, _, ss) = ParseStat(statValue);
                    baseStats[key] = bs;
                    scrollStats[key] = ss;
                }
            }

            var item = new CashEquipment
            {
                Name = name,
                Base = baseStats,
                Scroll = scrollStats,
                Category = category,
                ImageUrl = image,
                Upgrade = upgrade,
            };

            return item;
        }
    }
}
