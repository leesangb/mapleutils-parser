using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Parsers;
using MapleUtils.Parser.Test.Parsers.TestHelpers;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using static MapleUtils.Parser.Test.Parsers.TestHelpers.Expected;

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

        [TestCase(SpecsKeys.Spec1)]
        [TestCase(SpecsKeys.Spec2)]
        public void Parse_Test(SpecsKeys keyToTest)
        {
            var (text, expectedSpec) = Specs[keyToTest];

            var result = SpecParser.Parse(text);
            Assert.That(result, Is.EqualTo(expectedSpec));
        }


    }
}
