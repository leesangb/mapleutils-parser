using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Extensions;
using MapleUtils.Parser.Models;
using System.Text.RegularExpressions;

namespace MapleUtils.Parser.Parsers
{
    public class EquipmentParser : IEquipmentParser
    {
        private (string name, int upgrade, int star) ParseEquipmentName(string line)
        {
            var name = line;
            var starForceIndex = line.LastIndexOf("성 강화");
            var star = "";
            var upgrade = "";
            if (starForceIndex > 0)
            {
                name = line.Substring(0, starForceIndex - 2);
                star = line[(starForceIndex - 2)..];
            }

            var upgradeIndex = name.LastIndexOf("(+");
            if (upgradeIndex > 0)
            {
                name = line.Substring(0, upgradeIndex - 1);
                upgrade = line.Substring(upgradeIndex, line.LastIndexOf(")") - upgradeIndex);
            }

            return (name.Trim(), upgrade.ParseInt(), star.ParseInt());
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

        private (StatEnum, int)? ParsePotential(string line)
        {
            var option = line.Split(" : ");
            var isPercent = line.Contains("%") ? "%" : "";
            var stat = $"{option[0]}{isPercent}";
            if (option.Length != 2 || !Stats.StatMapping.TryGetValue(stat, out var key))
            {
                return null;
            }
            return (key, option[1].ParseInt());
        }

        public Equipment Parse(string text)
        {
            var lines = text.Replace("보스 몬스터\n공격 시 데미지", "보스 몬스터 공격 시 데미지").Split("\n").ToList();
            var nameIndex = 0;
            var soulIndex = -1;

            // 소울
            (StatEnum, int)? soul = null;
            var reqLevIndex = lines.FindIndex(l => l.StartsWith("REQ LEV"));
            if (reqLevIndex == 3)
            {
                soulIndex = lines.FindLastIndex(l => l.StartsWith("소울 충전 시")) - 1;
                var option = lines[soulIndex].Split(" : ");
                if (option.Length == 2 && Stats.StatMapping.TryGetValue(option[0], out var key))
                    soul = (key, option[1].ParseInt());
                nameIndex = 1;
            }

            // 이름, 강화, 별
            var (name, upgrade, star) = ParseEquipmentName(lines[nameIndex]);

            // 장비 분류
            var categoryIndex = lines.FindIndex(l => l.StartsWith("장비분류"));
            var category = lines[categoryIndex].Split(" | ")[1];
            category = Regex.Replace(category, " \\(.*", "");

            // 옵션
            var baseStatStartIndex = categoryIndex + 1;
            if (lines[baseStatStartIndex] == "공격속도")
            {
                baseStatStartIndex += 2;
            }
            var baseStatEndIndex = lines.FindLastIndex(l => l.StartsWith("잠재옵션") || l.StartsWith("가위 사용 가능"));

            var baseStat = new Dictionary<StatEnum, int>();
            var scrollStat = new Dictionary<StatEnum, int>();
            var flameStat = new Dictionary<StatEnum, int>();

            for (var i = baseStatStartIndex; i < baseStatEndIndex; i += 2)
            {
                var option = lines[i];
                var statValue = lines[i + 1];
                StatEnum key;

                if (option.StartsWith("Max") && statValue.Contains("%"))
                {
                    key = option == "MaxHP" ? StatEnum.HpP : StatEnum.MpP;
                    var value = statValue.ParseInt();
                    baseStat[key] = value;
                    flameStat[key] = 0;
                    scrollStat[key] = 0;
                }
                if (option.StartsWith("올") && statValue.Contains("%"))
                {
                    var (bs, fs, ss) = ParseStat(statValue);
                    baseStat[StatEnum.AllStatP] = bs;
                    flameStat[StatEnum.AllStatP] = fs;
                    scrollStat[StatEnum.AllStatP] = ss;
                }
                else if (Stats.StatMapping.TryGetValue(option, out key))
                {
                    var (bs, fs, ss) = ParseStat(statValue);
                    baseStat[key] = bs;
                    flameStat[key] = fs;
                    scrollStat[key] = ss;
                }

            }

            // 잠재능력
            var potentialIndex = lines.FindLastIndex(l => l.StartsWith("잠재옵션"));
            var additionalIndex = lines.FindLastIndex(l => l.StartsWith("에디셔널 잠재옵션"));
            var hasPotential = !lines[potentialIndex + 1].StartsWith("해당 사항이 없습니다");
            var hasAdditional = !lines[additionalIndex + 1].StartsWith("해당 사항이 없습니다");

            Potential potential = null;
            Potential additional = null;

            if (hasPotential)
            {
                potential = new Potential()
                {
                    Grade = PotentialGrade.Parse(lines[potentialIndex + 1].Split(" ")[0][1..].Trim()),
                    Effects = new List<(StatEnum, int)>()
                    .AddIfNotNull(ParsePotential(lines[potentialIndex + 2]))
                    .AddIfNotNull(ParsePotential(lines[potentialIndex + 3]))
                    .AddIfNotNull(ParsePotential(lines[potentialIndex + 4]))
                };
            }
            if (hasAdditional)
            {
                additional = new Potential()
                {
                    Grade = PotentialGrade.Parse(lines[additionalIndex + 1].Split(" ")[0][1..].Trim()),
                    Effects = new List<(StatEnum, int)>()
                    .AddIfNotNull(ParsePotential(lines[additionalIndex + 2]))
                    .AddIfNotNull(ParsePotential(lines[additionalIndex + 3]))
                    .AddIfNotNull(ParsePotential(lines[additionalIndex + 4]))
                };
            }

            var equipment = new Equipment()
            {
                Name = name,
                Upgrade = upgrade,
                Star = star,
                Category = category,
                Base = baseStat,
                Scroll = scrollStat,
                Flame = flameStat,
                Potential = potential,
                Additional = additional,
                Soul = soul,
                ImageUrl = lines.Last(),
            };

            return equipment;
        }
    }
}
