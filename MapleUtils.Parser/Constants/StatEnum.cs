using System.Text.Json.Serialization;

namespace MapleUtils.Parser.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatEnum
    {
        Str, // 힘
        Dex, // 덱
        Int, // 인
        Luk, // 럭
        StrP, // 힘퍼
        DexP, // 덱퍼
        IntP, // 인퍼
        LukP, // 럭퍼
        Hp, // HP
        HpP, // HP퍼
        Mp, // MP
        MpP, // MP퍼
        Atk, // 공격력
        AtkP, // 공격력퍼
        MAtk, // 마력
        MAtkP, // 마력퍼
        Def, // 물리방어력
        DefP, // 물리방어력%
        Speed, // 이동속도
        Jump, // 점프력
        IgnoreDef, // 방어율 무시%
        MobDmg, // 일반 몬스터 데미지%
        BossDmg, // 보스 몬스터 데미지%
        Dmg, // 데미지%
        AllStat, // 올스탯
        AllStatP, // 올스탯%
        Crit, // 크리티컬 확률
        CritDmg, // 크리티컬 데미지%
        Buff, // 버프지속시간
        StatusDmg, // 상태이상 데미지
        Arcane, // 아케인포스
        LvNAtk, // Lv n당 공1
        LvNMAtk, // Lv n당 마1
        Lv10Str, // Lv 10당 힘n
        Lv10Dex, // Lv 10당 덱n
        Lv10Int, // Lv 10당 인n
        Lv10Luk, // Lv 10당 럭n
        Meso, // 메소 획득량
        Drop, // 아이템 드롭률
        HpHeal, // 회복
        Passive, // 패시브 1렙
    }
}
