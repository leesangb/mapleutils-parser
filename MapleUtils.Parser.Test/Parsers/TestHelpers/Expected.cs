using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Models;
using System.Collections.Generic;
using System.IO;

namespace MapleUtils.Parser.Test.Parsers.TestHelpers
{
    internal static class Expected
    {
        internal static IList<(string text, Equipment expectedEquipment)> Equipments = new List<(string text, Equipment expectedEquipment)>()
        {
            (File.ReadAllText("Parsers/TestHelpers/Ring1.txt"), new Equipment()
            {
                Name = "웨폰퍼프 - L링",
                Category = "반지",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 4,
                    [StatEnum.Dex] = 4,
                    [StatEnum.Int] = 4,
                    [StatEnum.Luk] = 4,
                    [StatEnum.Atk] = 4,
                    [StatEnum.MAtk] = 4,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEODIGPH.png",
            }),
            (File.ReadAllText("Parsers/TestHelpers/Hat1.txt"), new Equipment()
            {
                Name = "앱솔랩스 시프캡",
                Category = "모자",
                Star = 22,
                Upgrade = 12,
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 45,
                    [StatEnum.Luk] = 45,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Atk] = 3,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 400,
                    [StatEnum.IgnoreDef] = 10,
                    [StatEnum.AllStatP] = 0,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 25,
                    [StatEnum.Dex] = 25,
                    [StatEnum.Luk] = 54,
                    [StatEnum.Hp] = 2400,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 0,
                    [StatEnum.IgnoreDef] = 0,
                    [StatEnum.AllStatP] = 6,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 94,
                    [StatEnum.Dex] = 131,
                    [StatEnum.Luk] = 208,
                    [StatEnum.Hp] = 1575,
                    [StatEnum.Atk] = 99,
                    [StatEnum.MAtk] = 92,
                    [StatEnum.Def] = 1116,
                    [StatEnum.IgnoreDef] = 0,
                    [StatEnum.AllStatP] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.LukP, 12),
                        (StatEnum.AllStatP, 6),
                        (StatEnum.LukP, 9)
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Epic,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.LukP, 4),
                        (StatEnum.Atk, 10),
                        (StatEnum.Luk, 10),
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEPCIOJJ.png",
            }),
            (File.ReadAllText("Parsers/TestHelpers/Emblem1.txt"), new Equipment()
            {
                Name = "금빛 천지인 엠블렘",
                Category = "엠블렘",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 10,
                    [StatEnum.Dex] = 10,
                    [StatEnum.Int] = 10,
                    [StatEnum.Luk] = 10,
                    [StatEnum.Atk] = 2,
                    [StatEnum.MAtk] = 2,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.IgnoreDef, 35),
                        (StatEnum.AtkP, 9),
                        (StatEnum.AtkP, 9)
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.AtkP, 12),
                        (StatEnum.AtkP, 9)
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEOLLCLB.png",
            })
        };


        internal static IList<(string text, Spec expectedSpec)> Specs = new List<(string text, Spec expectedSpec)>()
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
