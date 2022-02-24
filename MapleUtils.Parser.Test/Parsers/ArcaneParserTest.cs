using MapleUtils.Parser.Parsers;
using MapleUtils.Parser.Test.Parsers.TestHelpers;
using NUnit.Framework;
using static MapleUtils.Parser.Test.Parsers.TestHelpers.Expected;

namespace MapleUtils.Parser.Test.Parsers
{
    public class ArcaneParserTest
    {
        private ArcaneParser ArcaneParser;

        [SetUp]
        public void Setup()
        {
            ArcaneParser = new ArcaneParser();
        }

        [TestCase(ArcanesKeys.Arcane1)]
        [TestCase(ArcanesKeys.Arcane2)]
        public void Parse_Test(ArcanesKeys keyToTest)
        {
            var (text, expectedArcane) = Expected.Arcanes[keyToTest];

            var result = ArcaneParser.Parse(text);
            Assert.That(result.Name, Is.EqualTo(expectedArcane.Name));
            Assert.That(result.Level, Is.EqualTo(expectedArcane.Level));
            Assert.That(result.Experience, Is.EqualTo(expectedArcane.Experience));
            Assert.That(result.RequiredExperience, Is.EqualTo(expectedArcane.RequiredExperience));
            Assert.That(result.Stat, Is.EquivalentTo(expectedArcane.Stat));
        }
    }
}
