using MapleUtils.Parser.Models;
using System.Collections.Generic;
using System.IO;

namespace MapleUtils.Parser.Test.Parsers.TestHelpers
{
    internal static class ExpectedSpec
    {
        internal static IList<(string text, Spec expectedSpec)> ExpectedSpecs = new List<(string text, Spec expectedSpec)>()
        {
            (File.ReadAllText("Parsers/TestHelpers/Spec1.txt"), new Spec()
            {
                StatAtkLow = 5140180,
                StatAtkHigh = 5711310,
                Hp = 46843,
                Mp = 29393,
                Str = 1842,
                Dex = 3250,
                Int = 1611,
                Luk = 23899,
                CritDmg = 63,
                BossDmg = 227,
                IgnoreDef = 76,
                Resistance = 53,
                Stance = 100,
                Def = 31558,
                Speed = 160,
                Jump = 123,
                StarForce = 241,
                ArcaneForce = 1020,
            }),
            (File.ReadAllText("Parsers/TestHelpers/Spec2.txt"), new Spec()
            {
                StatAtkLow = 33179520,
                StatAtkHigh = 36461009,
                Hp = 52526,
                Mp = 27979,
                Str = 4524,
                Dex = 7603,
                Int = 3701,
                Luk = 47746,
                CritDmg = 108,
                BossDmg = 323,
                IgnoreDef = 94,
                Resistance = 59,
                Stance = 100,
                Def = 37046,
                Speed = 160,
                Jump = 123,
                StarForce = 324,
                ArcaneForce = 1350,
            })
        };
    }
}
