using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Extensions;

namespace MapleUtils.Parser.Parsers
{
    public class AbilitiesParser : IAbilitiesParser
    {
        private static void FillAbilitiesDefaultStats(Dictionary<StatEnum, int> abilities, string line)
        {
            StatEnum[] stats = { StatEnum.Str, StatEnum.Dex, StatEnum.Int, StatEnum.Luk };
            foreach (var stat in stats)
            {
                var uppercasedStat = stat.ToString().ToUpper();
                var statsInLine = line.Split(",");
                foreach (var statInLine in statsInLine)
                {
                    if (statInLine.Contains(uppercasedStat))
                    {
                        abilities[stat] = abilities.GetValueOrDefault(stat) + statInLine.ParseInt();
                    }
                }
            }
        }
        public IDictionary<StatEnum, int> Parse(string text)
        {
            var abilities = new Dictionary<StatEnum, int>();
            var lines = text.Split("\n");

            foreach(var line in lines)
            {
                var value = line.ParseInt();
                if (line.Contains("패시브"))
                {
                    abilities[StatEnum.Passive] = 1;
                }
                else if (line.Contains("보스"))
                {
                    abilities[StatEnum.BossDmg] = value;
                }
                else if (line.Contains("레벨마다 공격력"))
                {
                    abilities[StatEnum.LvNAtk] = value;
                }
                else if (line.Contains("레벨마다 마력"))
                {
                    abilities[StatEnum.LvNMAtk] = value;
                }
                else if (line.Contains("AP"))
                {
                    // FIXME: AP에 투자한 %만큼 증가
                }
                else if (line.Contains("공격력"))
                {
                    abilities[StatEnum.Atk] = value;
                }
                else if (line.Contains("마력"))
                {
                    abilities[StatEnum.MAtk] = value;
                }
                else if (line.Contains("크리"))
                {
                    abilities[StatEnum.Crit] = value;
                }
                else if (line.Contains("최대 HP"))
                {
                    if (line.Contains("%"))
                    {
                        abilities[StatEnum.HpP] = value;
                    }
                    else
                    {
                        abilities[StatEnum.Hp] = value;
                    }
                }
                else if (line.Contains("모든 능력치"))
                {
                    abilities[StatEnum.AllStat] = value;
                }
                else if (line.Contains("상태 이상에"))
                {
                    abilities[StatEnum.StatusDmg] = value;
                }
                else if (line.Contains("버프"))
                {
                    abilities[StatEnum.Buff] = value;
                }
                else
                {
                    FillAbilitiesDefaultStats(abilities, line);
                }
            }

            return abilities;
        }
    }
}
