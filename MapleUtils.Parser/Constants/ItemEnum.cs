namespace MapleUtils.Parser.Constants
{
    internal enum ItemEnum
    {
        Ring_1 = 1,
        Cap = 3,
        Emblem = 5,

        Ring_2 = 6,
        Pendant_1 = 7,
        Forehead = 8,
        Badge = 10,

        Ring_3 = 11,
        Pendant_2 = 12,
        Eyeacc = 13,
        Earacc = 14,
        Medal = 15,

        Ring_4 = 16,
        Weapon = 17,
        Clothes = 18,
        Shoulder = 19,
        SubWeapon = 20,

        Pocket = 21,
        Belt = 22,
        Pants = 23,
        Gloves = 24,
        Cape = 25,

        Shoes = 28,
        Android = 29,
        Heart = 30,
    }

    internal static class Items
    {
        internal static IReadOnlyList<ItemEnum> ITEMS_TO_PARSE = new List<ItemEnum>()
        {
            ItemEnum.Ring_1,
            ItemEnum.Cap,
            ItemEnum.Emblem,

            ItemEnum.Ring_2,
            ItemEnum.Pendant_1,
            ItemEnum.Forehead,
            ItemEnum.Badge,

            ItemEnum.Ring_3,
            ItemEnum.Pendant_2,
            ItemEnum.Eyeacc,
            ItemEnum.Earacc,
            ItemEnum.Medal,

            ItemEnum.Ring_4,
            ItemEnum.Weapon,
            ItemEnum.Clothes,
            ItemEnum.Shoulder,
            ItemEnum.SubWeapon,

            ItemEnum.Pocket,
            ItemEnum.Belt,
            ItemEnum.Pants,
            ItemEnum.Gloves,
            ItemEnum.Cape,

            ItemEnum.Shoes,
            ItemEnum.Android,
            ItemEnum.Heart,
        };
    }
}
