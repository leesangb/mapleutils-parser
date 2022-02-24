using MapleUtils.Parser.Parsers;
using MapleUtils.Parser.Test.Parsers.TestHelpers;
using NUnit.Framework;
using static MapleUtils.Parser.Test.Parsers.TestHelpers.Expected;

namespace MapleUtils.Parser.Test.Parsers
{
    public class PetEquipmentParserTest
    {
        private PetEquipmentParser PetEquipmentParser;

        [SetUp]
        public void Setup()
        {
            PetEquipmentParser = new PetEquipmentParser();
        }

        [TestCase(PetEquipmentsKeys.Pet1)]
        [TestCase(PetEquipmentsKeys.Pet2)]
        public void Parse_Test(PetEquipmentsKeys keyToTest)
        {
            var (text, expected) = Expected.PetEquipments[keyToTest];

            var result = PetEquipmentParser.Parse(text);
            Assert.That(result.Name, Is.EqualTo(expected.Name));
            Assert.That(result.Category, Is.EqualTo(expected.Category));
            Assert.That(result.Upgrade, Is.EqualTo(expected.Upgrade));
            Assert.That(result.ImageUrl, Is.EqualTo(expected.ImageUrl));
            Assert.That(result.Base, Is.EquivalentTo(expected.Base));
            Assert.That(result.Scroll, Is.EquivalentTo(expected.Scroll));
        }
    }
}
