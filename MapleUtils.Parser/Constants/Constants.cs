namespace MapleUtils.Parser.Constants
{
    internal static class Constants
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


        internal const string MAPLESTORY_HOME = "https://maplestory.nexon.com";
        internal const string MAPLESTORY_RANKING_SEARCH = $"{MAPLESTORY_HOME}/Ranking/World/Total";
    }
}
