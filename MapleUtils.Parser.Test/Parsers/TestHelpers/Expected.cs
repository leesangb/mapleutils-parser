using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Models;
using System.Collections.Generic;
using System.IO;

namespace MapleUtils.Parser.Test.Parsers.TestHelpers
{
    public static class Expected
    {
        public enum EquipmentsKeys
        {
            Ring1,
            Hat1,
            EyeAccessory1,
            Weapon1,
            Earring1,
            SubWeapon1,
            Ring2,
            Heart1,
            Pocket1,
            Android1,
            Gloves1,
            Pendant1,
            Badge1,
            Shoes1,
        }


        internal static IDictionary<EquipmentsKeys, (string text, Equipment expectedEquipment)> Equipments = new Dictionary<EquipmentsKeys, (string text, Equipment expectedEquipment)>()
        {
            [EquipmentsKeys.Ring1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Ring1.txt"), new Equipment()
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
            [EquipmentsKeys.Hat1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Hat1.txt"), new Equipment()
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
            [EquipmentsKeys.EyeAccessory1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/EyeAccessory1.txt"), new Equipment()
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
            }),
            [EquipmentsKeys.Weapon1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Weapon1.txt"), new Equipment()
            {
                Name = "아케인셰이드 초선",
                Category = "부채",
                Star = 18,
                Upgrade = 9,
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 100,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 100,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 276,
                    [StatEnum.BossDmg] = 30,
                    [StatEnum.IgnoreDef] = 20,
                    [StatEnum.Dmg] = 0,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 102,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 36,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 170,
                    [StatEnum.BossDmg] = 0,
                    [StatEnum.IgnoreDef] = 0,
                    [StatEnum.Dmg] = 6,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 85,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 121,
                    [StatEnum.Hp] = 255,
                    [StatEnum.Mp] = 255,
                    [StatEnum.Atk] = 254,
                    [StatEnum.BossDmg] = 0,
                    [StatEnum.IgnoreDef] = 0,
                    [StatEnum.Dmg] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.BossDmg, 40),
                        (StatEnum.AtkP, 9),
                        (StatEnum.IgnoreDef, 30),
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Unique,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.AtkP, 9),
                        (StatEnum.AtkP, 6),
                        (StatEnum.Crit, 6)
                    }
                },
                Soul = (StatEnum.AtkP, 3),
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KENLJHMD.png",
            }),
            [EquipmentsKeys.Earring1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Earring1.txt"), new Equipment()
            {
                Name = "마이스터 이어링",
                Star = 22,
                Upgrade = 7,
                Category = "귀고리",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 5,
                    [StatEnum.Dex] = 5,
                    [StatEnum.Int] = 5,
                    [StatEnum.Luk] = 5,
                    [StatEnum.Hp] = 500,
                    [StatEnum.Mp] = 500,
                    [StatEnum.Atk] = 4,
                    [StatEnum.MAtk] = 4,
                    [StatEnum.Def] = 70,
                    [StatEnum.Jump] = 0,
                    [StatEnum.AllStatP] = 0,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 24,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 72,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 0,
                    [StatEnum.Jump] = 5,
                    [StatEnum.AllStatP] = 5,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 103,
                    [StatEnum.Dex] = 103,
                    [StatEnum.Int] = 103,
                    [StatEnum.Luk] = 103,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 106,
                    [StatEnum.MAtk] = 78,
                    [StatEnum.Def] = 155,
                    [StatEnum.Jump] = 0,
                    [StatEnum.AllStatP] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.LukP, 12),
                        (StatEnum.LukP, 9),
                        (StatEnum.AllStatP, 6),
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Epic,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.Atk, 11),
                        (StatEnum.Atk, 10),
                        (StatEnum.LukP, 2)
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEPBJHHD.png"
            }),
            [EquipmentsKeys.SubWeapon1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/SubWeapon1.txt"), new Equipment()
            {
                Name = "월장석 선추",
                Category = "선추",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Dex] = 10,
                    [StatEnum.Luk] = 10,
                    [StatEnum.Atk] = 3,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Dex] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Dex] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.BossDmg, 30),
                        (StatEnum.BossDmg, 30),
                        (StatEnum.AtkP, 9),
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.AtkP, 12),
                        (StatEnum.AtkP, 9),
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEMHIPOC.png"
            }),
            [EquipmentsKeys.Ring2] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Ring2.txt"), new Equipment()
            {
                Name = "글로리온 링 : 슈프림",
                Category = "반지",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 40,
                    [StatEnum.Dex] = 40,
                    [StatEnum.Int] = 40,
                    [StatEnum.Luk] = 40,
                    [StatEnum.Hp] = 4000,
                    [StatEnum.Mp] = 4000,
                    [StatEnum.Atk] = 25,
                    [StatEnum.MAtk] = 25,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.LukP, 12),
                        (StatEnum.AllStatP, 9),
                        (StatEnum.LukP, 9)
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Rare,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.Jump, 6),
                        (StatEnum.Atk, 10),
                        (StatEnum.Def, 60)
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEODPEPH.png"
            }),
            [EquipmentsKeys.Pendant1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Pendant1.txt"), new Equipment()
            {
                Name = "도미네이터 펜던트",
                Upgrade = 6,
                Star = 17,
                Category = "펜던트",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 20,
                    [StatEnum.Dex] = 20,
                    [StatEnum.Int] = 20,
                    [StatEnum.Luk] = 20,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.HpP] = 10,
                    [StatEnum.MpP] = 10,
                    [StatEnum.Atk] = 3,
                    [StatEnum.MAtk] = 3,
                    [StatEnum.Def] = 100,
                    [StatEnum.Speed] = 0,
                    [StatEnum.Jump] = 0,
                    [StatEnum.AllStatP] = 0
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 24,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 72,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 2100,
                    [StatEnum.HpP] = 0,
                    [StatEnum.MpP] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 0,
                    [StatEnum.Speed] = 0,
                    [StatEnum.Jump] = 0,
                    [StatEnum.AllStatP] = 4
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 74,
                    [StatEnum.Dex] = 74,
                    [StatEnum.Int] = 77,
                    [StatEnum.Luk] = 74,
                    [StatEnum.Hp] = 455,
                    [StatEnum.Mp] = 200,
                    [StatEnum.HpP] = 0,
                    [StatEnum.MpP] = 0,
                    [StatEnum.Atk] = 38,
                    [StatEnum.MAtk] = 32,
                    [StatEnum.Def] = 429,
                    [StatEnum.Speed] = 15,
                    [StatEnum.Jump] = 14,
                    [StatEnum.AllStatP] = 0
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Unique,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.LukP, 9),
                        (StatEnum.MpP, 6),
                        (StatEnum.LukP, 9),
                    }
                },
                Additional = new Potential
                {
                    Grade = PotentialGradeEnum.Rare,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.Atk, 10),
                        (StatEnum.Luk, 6),
                        (StatEnum.Def, 60)
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEOAJGLB.png"
            }),
            [EquipmentsKeys.Badge1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Badge1.txt"), new Equipment()
            {
                Name = "크리스탈 웬투스 뱃지",
                Category = "뱃지",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 10,
                    [StatEnum.Dex] = 10,
                    [StatEnum.Int] = 10,
                    [StatEnum.Luk] = 10,
                    [StatEnum.Atk] = 5,
                    [StatEnum.MAtk] = 5,
                    [StatEnum.Speed] = 10,
                    [StatEnum.Jump] = 10,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Speed] = 0,
                    [StatEnum.Jump] = 0,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Speed] = 0,
                    [StatEnum.Jump] = 0,
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEOKJHGG.png"
            }),
            [EquipmentsKeys.Heart1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Heart1.txt"), new Equipment()
            {
                Name = "페어리 하트",
                Category = "기계 심장",
                Star = 8,
                Upgrade = 10,
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Hp] = 100,
                    [StatEnum.Atk] = 0
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Atk] = 0
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 19,
                    [StatEnum.Dex] = 19,
                    [StatEnum.Int] = 19,
                    [StatEnum.Luk] = 19,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Atk] = 50
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Unique,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.LukP, 9),
                        (StatEnum.LukP, 6),
                        (StatEnum.MpP, 6),
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Rare,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.Atk, 10),
                        (StatEnum.Def, 50),
                        (StatEnum.Hp, 50),
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEJFJHJI.png",
            }),
            [EquipmentsKeys.Android1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Android1.txt"), new Equipment()
            {
                Name = "페어리로이드(남)",
                Category = "안드로이드",
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEJEJHGD.png",
                Base = new Dictionary<StatEnum, int>(),
                Flame = new Dictionary<StatEnum, int>(),
                Scroll = new Dictionary<StatEnum, int>(),
            }),
            [EquipmentsKeys.Shoes1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Shoes1.txt"), new Equipment()
            {
                Name = "앱솔랩스 시프슈즈",
                Upgrade = 8,
                Star = 22,
                Category = "신발",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 20,
                    [StatEnum.Luk] = 20,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Atk] = 5,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 150,
                    [StatEnum.Speed] = 10,
                    [StatEnum.Jump] = 7,
                    [StatEnum.AllStatP] = 0
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 20,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Luk] = 74,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 36,
                    [StatEnum.Speed] = 0,
                    [StatEnum.Jump] = 0,
                    [StatEnum.AllStatP] = 5
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 131,
                    [StatEnum.Luk] = 187,
                    [StatEnum.Hp] = 960,
                    [StatEnum.Atk] = 93,
                    [StatEnum.MAtk] = 92,
                    [StatEnum.Def] = 547,
                    [StatEnum.Speed] = 18,
                    [StatEnum.Jump] = 10,
                    [StatEnum.AllStatP] = 0
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.AllStatP, 9),
                        (StatEnum.LukP, 9),
                        (StatEnum.LukP, 9),
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Epic,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.LukP, 4),
                        (StatEnum.Dex, 14),
                        (StatEnum.LukP, 4)
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEPFIHNF.png"
            }),
            [EquipmentsKeys.Gloves1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Gloves1.txt"), new Equipment()
            {
                Name = "앱솔랩스 시프글러브",
                Upgrade = 8,
                Star = 22,
                Category = "장갑",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Dex] = 20,
                    [StatEnum.Luk] = 20,
                    [StatEnum.Atk] = 5,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 150,
                    [StatEnum.Speed] = 0,
                    [StatEnum.AllStatP] = 0,
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Dex] = 25,
                    [StatEnum.Luk] = 70,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.Def] = 0,
                    [StatEnum.Speed] = 3,
                    [StatEnum.AllStatP] = 6,
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Dex] = 131,
                    [StatEnum.Luk] = 131,
                    [StatEnum.Atk] = 123,
                    [StatEnum.MAtk] = 92,
                    [StatEnum.Def] = 306,
                    [StatEnum.Speed] = 0,
                    [StatEnum.AllStatP] = 0,
                },
                Potential = new Potential()
                {
                    Grade = PotentialGradeEnum.Legendary,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.CritDmg, 8),
                        (StatEnum.CritDmg, 8),
                        (StatEnum.DexP, 9),
                    }
                },
                Additional = new Potential()
                {
                    Grade = PotentialGradeEnum.Epic,
                    Effects = new List<(StatEnum, int)>()
                    {
                        (StatEnum.Atk, 11),
                        (StatEnum.Def, 120),
                        (StatEnum.LukP, 4)
                    }
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEPKJBNI.png"
            }),
            [EquipmentsKeys.Pocket1] = (File.ReadAllText("Parsers/TestHelpers/Equipments/Pocket1.txt"), new Equipment()
            {
                Name = "핑크빛 성배",
                Category = "포켓 아이템",
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 5,
                    [StatEnum.Dex] = 5,
                    [StatEnum.Int] = 5,
                    [StatEnum.Luk] = 5,
                    [StatEnum.Hp] = 50,
                    [StatEnum.Mp] = 50,
                    [StatEnum.Atk] = 5,
                    [StatEnum.MAtk] = 5,
                    [StatEnum.AllStatP] = 0
                },
                Flame = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 20,
                    [StatEnum.Dex] = 16,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 84,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.AllStatP] = 4
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Str] = 0,
                    [StatEnum.Dex] = 0,
                    [StatEnum.Int] = 0,
                    [StatEnum.Luk] = 0,
                    [StatEnum.Hp] = 0,
                    [StatEnum.Mp] = 0,
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 0,
                    [StatEnum.AllStatP] = 0
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEOEJHME.png",
            }),
        };

        public enum SpecsKeys
        {
            Spec1,
            Spec2,
        }

        internal static IDictionary<SpecsKeys, (string text, Spec expectedSpec)> Specs = new Dictionary<SpecsKeys, (string text, Spec expectedSpec)>()
        {
            [SpecsKeys.Spec1] = (File.ReadAllText("Parsers/TestHelpers/Specs/Spec1.txt"), new Spec()
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
            [SpecsKeys.Spec2] = (File.ReadAllText("Parsers/TestHelpers/Specs/Spec2.txt"), new Spec()
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

        public enum ArcanesKeys
        {
            Arcane1,
            Arcane2,
        }

        internal static IDictionary<ArcanesKeys, (string text, Symbol symbol)> Arcanes = new Dictionary<ArcanesKeys, (string text, Symbol symbol)>()
        {
            [ArcanesKeys.Arcane1] = (File.ReadAllText("Parsers/TestHelpers/Arcanes/Arcane1.txt"), new Symbol()
            {
                Name = "아케인심볼 : 소멸의 여로",
                Level = 14,
                Stat = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Luk] = 1600
                },
                Experience = 98,
                RequiredExperience = 207,
            }),
            [ArcanesKeys.Arcane2] = (File.ReadAllText("Parsers/TestHelpers/Arcanes/Arcane2.txt"), new Symbol()
            {
                Name = "아케인심볼 : 츄츄 아일랜드",
                Level = 15,
                Stat = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Luk] = 1700
                },
                Experience = 199,
                RequiredExperience = 236,
            })
        };

        public enum PetEquipmentsKeys
        {
            Pet1,
            Pet2,
        }

        internal static IDictionary<PetEquipmentsKeys, (string text, CashEquipment equipment)> PetEquipments = new Dictionary<PetEquipmentsKeys, (string text, CashEquipment equipment)>()
        {
            [PetEquipmentsKeys.Pet1] = (File.ReadAllText("Parsers/TestHelpers/PetEquipments/Pet1.txt"), new CashEquipment()
            {
                Name = "푸른 밤 나비",
                Category = "펫장비",
                Upgrade = 7,
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Atk] = 10,
                    [StatEnum.MAtk] = 10
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 29
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEHCJAJA.png"
            }),
            [PetEquipmentsKeys.Pet2] = (File.ReadAllText("Parsers/TestHelpers/PetEquipments/Pet2.txt"), new CashEquipment()
            {
                Name = "루나 크리스탈 키",
                Category = "펫장비",
                Upgrade = 8,
                Base = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Atk] = 10,
                    [StatEnum.MAtk] = 10
                },
                Scroll = new Dictionary<StatEnum, int>()
                {
                    [StatEnum.Atk] = 0,
                    [StatEnum.MAtk] = 34
                },
                ImageUrl = "https://avatar.maplestory.nexon.com/ItemIcon/KEGHJHOF.png"
            }),
        };
    }
}
