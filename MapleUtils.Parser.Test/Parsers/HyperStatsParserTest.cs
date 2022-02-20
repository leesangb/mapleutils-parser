using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Parsers;
using NUnit.Framework;

namespace MapleUtils.Parser.Test.Parsers
{
    public class HyperStatsParserTest
    {
        private HyperStatsParser HyperStatsParser;

        [SetUp]
        public void Setup()
        {
            HyperStatsParser = new HyperStatsParser();
        }

        [TestCase("힘 30 증가", StatEnum.Str, 30)]
        [TestCase("민첩성 60 증가", StatEnum.Dex, 60)]
        [TestCase("지력 90 증가", StatEnum.Int, 90)]
        [TestCase("운 120 증가", StatEnum.Luk, 120)]
        [TestCase("최대 HP 2% 증가", StatEnum.HpP, 2)]
        [TestCase("크리티컬 확률 3% 증가", StatEnum.Crit, 3)]
        [TestCase("크리티컬 데미지 9% 증가", StatEnum.CritDmg, 9)]
        [TestCase("보스 몬스터 공격 시 데미지 51% 증가", StatEnum.BossDmg, 51)]
        [TestCase("일반 몬스터 공격 시 데미지 6% 증가", StatEnum.MobDmg, 6)]
        [TestCase("데미지 30% 증가", StatEnum.Dmg, 30)]
        [TestCase("방어율 무시 24% 증가", StatEnum.IgnoreDef, 24)]
        [TestCase("아케인포스 무시 25 증가", StatEnum.Arcane, 25)]
        public void Parse_Test(string text, StatEnum expectedKey, int expectedValue)
        {
            var result = HyperStatsParser.Parse(text);

            Assert.That(result.ContainsKey(expectedKey));
            Assert.That(result[expectedKey], Is.EqualTo(expectedValue));
        }


        [TestCase("공격력과 마력 30 증가", StatEnum.Atk, StatEnum.MAtk, 30)]
        public void Parse_Test(string text, StatEnum expectedKey1, StatEnum expectedKey2, int expectedValue)
        {
            var result = HyperStatsParser.Parse(text);

            Assert.That(result.ContainsKey(expectedKey1));
            Assert.That(result[expectedKey1], Is.EqualTo(expectedValue));
            Assert.That(result.ContainsKey(expectedKey2));
            Assert.That(result[expectedKey2], Is.EqualTo(expectedValue));
        }
    }
}
