using MapleUtils.Parser.Constants;

namespace MapleUtils.Parser.Models
{
    public record Spec
    {
        /// <summary>
        /// 앞 스공
        /// </summary>
        public int StatAtkLow { get; init; }

        /// <summary>
        /// 뒷 스공
        /// </summary>
        public int StatAtkHigh { get; init; }

        /// <summary>
        /// HP
        /// </summary>
        public int Hp { get; init; }

        /// <summary>
        /// MP
        /// </summary>
        public int Mp { get; init; }

        /// <summary>
        /// 힘
        /// </summary>
        public int Str { get; init; }

        /// <summary>
        /// 덱
        /// </summary>
        public int Dex { get; init; }

        /// <summary>
        /// 인
        /// </summary>
        public int Int { get; init; }

        /// <summary>
        /// 럭
        /// </summary>
        public int Luk { get; init; }

        /// <summary>
        /// 크리 데미지
        /// </summary>
        public double CritDmg { get; init; }

        /// <summary>
        /// 보스 데미지
        /// </summary>
        public int BossDmg { get; init; }

        /// <summary>
        /// 방어율 무시
        /// </summary>
        public double IgnoreDef { get; init; }

        /// <summary>
        /// 데미지
        /// </summary>
        public int Dmg { get; init; }

        /// <summary>
        /// 상태이상 내성
        /// </summary>
        public int Resistance { get; init; }

        /// <summary>
        /// 스탠스
        /// </summary>
        public int Stance { get; init; }

        /// <summary>
        /// 방어력
        /// </summary>
        public int Def { get; init; }

        /// <summary>
        /// 이동속도
        /// </summary>
        public int Speed { get; init; }

        /// <summary>
        /// 점프력
        /// </summary>
        public int Jump { get; init; }

        /// <summary>
        /// 스타포스
        /// </summary>
        public int StarForce { get; init; }

        /// <summary>
        /// 아케인포스
        /// </summary>
        public int ArcaneForce { get; init; }

        /// <summary>
        /// 어센틱포스
        /// </summary>
        public int AuthenticForce { get; init; }

        /// <summary>
        /// 어빌리티
        /// </summary>
        public IDictionary<StatEnum, int> Abilities { get; init; }

        /// <summary>
        /// 하이퍼스탯
        /// </summary>
        public IDictionary<StatEnum, int> Hypers { get; init; }
    }
}
