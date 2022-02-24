namespace MapleUtils.Parser.Constants
{
    internal static class Sites
    {
        internal const string MAPLESTORY_HOME = "https://maplestory.nexon.com";
        internal const string MAPLESTORY_RANKING_SEARCH = $"{MAPLESTORY_HOME}/Ranking/World/Total";
        internal const string MAPLESTORY_CHARACTER_DETAIL = "https://maplestory.nexon.com/Common/Character/Detail";

        internal static string GetRankingSearchUrl(string nickName) => $"{MAPLESTORY_RANKING_SEARCH}?c={nickName}";
    }
}
