using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Models;
using System.Collections.Generic;
using System.IO;

namespace MapleUtils.Parser.Test.Parsers.TestHelpers
{
    internal static class Expected
    {
        internal static IDictionary<string, (string text, Equipment expectedEquipment)> Equipments = new Dictionary<string, (string text, Equipment expectedEquipment)>()
        {
            ["반지1"] = (File.ReadAllText("Parsers/TestHelpers/Ring1.txt"), new Equipment()
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
            ["모자1"] = (File.ReadAllText("Parsers/TestHelpers/Hat1.txt"), new Equipment()
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
            ["눈장식1"] = (File.ReadAllText("Parsers/TestHelpers/EyeAccessory1.txt"), new Equipment()
            {
                Name = "블랙빈 마크",
                Category = "눈장식",
                Star = 17,
                Upgrade = 6,
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 7,
                    [StatEnum.Dex] = 7,
                    [StatEnum.Int] = 7,
                    [StatEnum.Luk] = 7,
                    [StatEnum.Atk] = 1,
                    [StatEnum.MAtk] = 1,
                    [StatEnum.Def] = 120,
                    [StatEnum.Jump] = 0,
                    [StatEnum.AllStatP] = 0,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 12,
                    [StatEnum.Luk] = 40,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 0,
                    [StatEnum.Jump] = 3,
                    [StatEnum.AllStatP] = 6,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 68,
                    [StatEnum.Dex] = 64,
                    [StatEnum.Int] = 67,
                    [StatEnum.Luk] = 68,
                    [StatEnum.Atk] = 24,
                    [StatEnum.MAtk] = 26,
                    [StatEnum.Def] = 202,
                    [StatEnum.Jump] = 11,
                    [StatEnum.AllStatP] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Unique,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.AllStatP, 6),
                        (StatEnum.LukP, 6),
                        (StatEnum.LukP, 6)
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Unique,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.Lv10Luk, 1),
                        (StatEnum.Atk, 11),
                        (StatEnum.Speed, 8)
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEPAJFND.png",
            })
        };


        internal static IDictionary<string, (string text, Spec expectedSpec)> Specs = new Dictionary<string, (string text, Spec expectedSpec)>()
        {
            ["스펙1"] = (File.ReadAllText("Parsers/TestHelpers/Spec1.txt"), new Spec()
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
            ["스펙2"] = (File.ReadAllText("Parsers/TestHelpers/Spec2.txt"), new Spec()
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
