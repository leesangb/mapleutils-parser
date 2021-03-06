using MapleUtils.Parser.Parsers;
using MapleUtils.Parser.Test.Parsers.TestHelpers;
using NUnit.Framework;
using static MapleUtils.Parser.Test.Parsers.TestHelpers.Expected;

namespace MapleUtils.Parser.Test.Parsers
{
    public class EquipmentParserTest
    {
        private EquipmentParser EquipmentParser;

        [SetUp]
        public void Setup()
        {
            EquipmentParser = new EquipmentParser();
        }

        [TestCase(EquipmentsKeys.Ring1)]
        [TestCase(EquipmentsKeys.Hat1)]
        [TestCase(EquipmentsKeys.EyeAccessory1)]
        [TestCase(EquipmentsKeys.Weapon1)]
        [TestCase(EquipmentsKeys.Earring1)]
        [TestCase(EquipmentsKeys.SubWeapon1)]
        [TestCase(EquipmentsKeys.Ring2)]
        [TestCase(EquipmentsKeys.Heart1)]
        [TestCase(EquipmentsKeys.Pocket1)]
        [TestCase(EquipmentsKeys.Android1)]
        [TestCase(EquipmentsKeys.Gloves1)]
        [TestCase(EquipmentsKeys.Pendant1)]
        [TestCase(EquipmentsKeys.Badge1)]
        [TestCase(EquipmentsKeys.Shoes1)]
        public void Parse_Test(EquipmentsKeys keyToTest)
        {
            var (text, expectedEquipment) = Expected.Equipments[keyToTest];

            var result = EquipmentParser.Parse(text);
            Assert.That(result.Name, Is.EqualTo(expectedEquipment.Name));
            Assert.That(result.Grade, Is.EqualTo(expectedEquipment.Grade));
            Assert.That(result.ImageUrl, Is.EqualTo(expectedEquipment.ImageUrl));
            Assert.That(result.Category, Is.EqualTo(expectedEquipment.Category));
            Assert.That(result.Upgrade, Is.EqualTo(expectedEquipment.Upgrade));
            Assert.That(result.Base, Is.EquivalentTo(expectedEquipment.Base));
            Assert.That(result.Flame, Is.EquivalentTo(expectedEquipment.Flame));
            Assert.That(result.Scroll, Is.EquivalentTo(expectedEquipment.Scroll));
            Assert.That(result.Star, Is.EqualTo(expectedEquipment.Star));

            if (expectedEquipment.Potential != null)
            {
                Assert.That(result.Potential.Effects, Is.EquivalentTo(expectedEquipment.Potential.Effects));
                Assert.That(result.Potential.Grade, Is.EqualTo(expectedEquipment.Potential.Grade));
            }
            if (expectedEquipment.Additional != null)
            {
                Assert.That(result.Additional.Effects, Is.EquivalentTo(expectedEquipment.Additional.Effects));
                Assert.That(result.Additional.Grade, Is.EqualTo(expectedEquipment.Additional.Grade));
            }

            Assert.That(result.Soul, Is.EqualTo(expectedEquipment.Soul));
        }
    }
}
