using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Parsers;
using MapleUtils.Parser.Test.Parsers.TestHelpers;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace MapleUtils.Parser.Test.Parsers
{
    public class SpecParserTest
    {
        private SpecParser SpecParser;

        [SetUp]
        public void Setup()
        {
            IDictionary<StatEnum, int> nullResult = null;
            var abilitiesParserMock = Substitute.For<IAbilitiesParser>();
            abilitiesParserMock.Parse(default).ReturnsForAnyArgs(nullResult);
            var hyperStatsParserMock = Substitute.For<IHyperStatsParser>();
            hyperStatsParserMock.Parse(default).ReturnsForAnyArgs(nullResult);

            SpecParser = new SpecParser(abilitiesParserMock, hyperStatsParserMock);
        }

        [Test]
        public void Parse_Test()
        {
            foreach (var (text, expectedSpec) in ExpectedSpec.ExpectedSpecs)
            {
                var result = SpecParser.Parse(text);
                Assert.That(result, Is.EqualTo(expectedSpec));
            }
        }


    }
}
