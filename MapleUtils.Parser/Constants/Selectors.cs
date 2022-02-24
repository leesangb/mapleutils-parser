namespace MapleUtils.Parser.Constants
{
    internal static class Selectors
    {
        internal const string EQUIP_LINK = "#container > div.con_wrap > div.lnb_wrap > ul > li:nth-child(3) > a";
        internal const string PET_LINK = "#container > div.con_wrap > div.lnb_wrap > ul > li:nth-child(10) > a";

        internal const string GENERAL_INFO_TABLE = "div.tab01_con_wrap > table:nth-child(2) > tbody";
        internal const string SPEC_INFO_TABLE = "div.tab01_con_wrap > table:nth-child(4) > tbody";

        internal const string CHAR_INFO_LEVEL = "div.char_info > dl:nth-child(1) > dd";
        internal const string CHAR_IMAGE = "div.char_info > div.char_img > div > img"; 
        
        internal const string EQUIPMENT_LIST_ITEM = "div.tab01_con_wrap > div.weapon_wrap > ul > li:nth-child({0})";
        internal const string ITEM_CONTENT = "div.tab01_con_wrap > div.item_info";

        internal const string OTHER_EQUIPMENT_TAB_SELECTOR = "div.tab_menu > ul > li:nth-child(4) > a";

        internal const string ARCANE_INFO_TAB = "div.tab_menu > ul > li:nth-child(3) > a";
        internal const string ARCANE_INFO = "div.tab03_con_wrap > div.arcane_weapon_wrap > ul > li.ac_pot0";

        internal const string PET_INFO_TAB_SELECTOR = "div.tab_menu > ul > li:nth-child(2) > a";
        private const string PET_INFO_SELECTOR = "div.tab02_con_wrap > div > ul > li:nth-child({0})";

        internal static string GetArcaneInfoNumber(int i) => $"{ARCANE_INFO}{i}";
        internal static string GetPetInfoNumber(int i) => string.Format(PET_INFO_SELECTOR, i);
    }
}
