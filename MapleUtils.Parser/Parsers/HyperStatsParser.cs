using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Extensions;

namespace MapleUtils.Parser.Parsers
{
    public class HyperStatsParser : IHyperStatsParser
    {
        public IDictionary<StatEnum, int> Parse(string text)
        {
            var hyperStats = new Dictionary<StatEnum, int>();
            var lines = text.Split("\n");

            foreach (var line in lines)
            {
                var value = line.ParseInt();
                if (line.StartsWith("힘"))
                {
                    hyperStats[StatEnum.Str] = value;
                }
                else if (line.StartsWith("민첩성"))
                {
                    hyperStats[StatEnum.Dex] = value;
                }
                else if (line.StartsWith("지력"))
                {
                    hyperStats[StatEnum.Int] = value;
                }
                else if (line.StartsWith("운"))
                {
                    hyperStats[StatEnum.Luk] = value;
                }
                else if (line.StartsWith("최대 HP"))
                {
                    hyperStats[StatEnum.HpP] = value;
                }
                else if (line.StartsWith("크리티컬 확률"))
                {
                    hyperStats[StatEnum.Crit] = value;
                }
                else if (line.StartsWith("크리티컬 데미지"))
                {
                    hyperStats[StatEnum.CritDmg] = value;
                }
                else if (line.StartsWith("공격력"))
                {
                    hyperStats[StatEnum.Atk] = value;
                    hyperStats[StatEnum.MAtk] = value;
                }
                else if (line.StartsWith("보스"))
                {
                    hyperStats[StatEnum.BossDmg] = value;
                }
                else if (line.StartsWith("일반"))
                {
                    hyperStats[StatEnum.MobDmg] = value;
                }
                else if (line.StartsWith("데미지"))
                {
                    hyperStats[StatEnum.Dmg] = value;
                }
                else if (line.StartsWith("방어율"))
                {
                    hyperStats[StatEnum.IgnoreDef] = value;
                }
                else if (line.StartsWith("아케인"))
                {
                    hyperStats[StatEnum.Arcane] = value;
                }
            }

            return hyperStats;
        }
    }
}
