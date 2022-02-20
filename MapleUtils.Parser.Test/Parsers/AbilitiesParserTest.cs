using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Parsers;
using NUnit.Framework;

namespace MapleUtils.Parser.Test.Parsers
{
    public class AbilitiesParserTest
    {
        private AbilitiesParser AbilitiesParser;

        [SetUp]
        public void Setup()
        {
            AbilitiesParser = new AbilitiesParser();
        }

        [TestCase("패시브 스킬 레벨이 1 증가 (액티브 혼합형, 5차스킬 적용안됨)", StatEnum.Passive, 1)]
        [TestCase("보스 몬스터 공격 시 데미지 17% 증가", StatEnum.BossDmg, 17)]
        [TestCase("STR 6 증가", StatEnum.Str, 6)]
        [TestCase("DEX 12 증가", StatEnum.Dex, 12)]
        [TestCase("INT 5 증가", StatEnum.Int, 5)]
        [TestCase("LUK 35 증가", StatEnum.Luk, 35)]
        [TestCase("모든 능력치 10 증가", StatEnum.AllStat, 10)]
        [TestCase("크리티컬 확률 7% 증가", StatEnum.Crit, 7)]
        [TestCase("최대 HP 350 증가", StatEnum.Hp, 350)]
        [TestCase("공격력 9 증가", StatEnum.Atk, 9)]
        [TestCase("마력 25 증가", StatEnum.MAtk, 25)]
        [TestCase("상태 이상에 걸린 대상 공격 시 데미지 7% 증가", StatEnum.StatusDmg, 7)]
        [TestCase("버프 스킬의 지속 시간 48% 증가", StatEnum.Buff, 48)]
        public void Parse_Test(string text, StatEnum expectedKey, int expectedValue)
        {
            var result = AbilitiesParser.Parse(text);

            Assert.That(result.ContainsKey(expectedKey));
            Assert.That(result[expectedKey], Is.EqualTo(expectedValue));
        }

        [TestCase("STR 10 증가, DEX 4증가", StatEnum.Str, 10, StatEnum.Dex, 4)]
        [TestCase("LUK 17 증가, DEX 9증가", StatEnum.Luk, 17, StatEnum.Dex, 9)]
        [TestCase("INT 20 증가, LUK 11증가", StatEnum.Int, 20, StatEnum.Luk, 11)]
        [TestCase("DEX 12 증가, STR 5증가", StatEnum.Dex, 12, StatEnum.Str, 5)]
        public void Parse_Test(string text, StatEnum expectedKey1, int expectedValue1, StatEnum expectedKey2, int expectedValue2)
        {
            var result = AbilitiesParser.Parse(text);
            Assert.That(result.ContainsKey(expectedKey1));
            Assert.That(result[expectedKey1], Is.EqualTo(expectedValue1));
            Assert.That(result.ContainsKey(expectedKey2));
            Assert.That(result[expectedKey2], Is.EqualTo(expectedValue2));
        }
    }
}
