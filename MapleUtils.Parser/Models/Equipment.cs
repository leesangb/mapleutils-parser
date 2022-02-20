using MapleUtils.Parser.Constants;

namespace MapleUtils.Parser.Models
{
    public record Potential
    {
        /// <summary>
        /// 등급
        /// </summary>
        public PotentialGradeEnum Grade { get; init; }

        /// <summary>
        /// 효과
        /// </summary>
        public IList<KeyValuePair<StatEnum, int>> Effects { get; init; }
    }
    public abstract record EquipmentBase
    {
        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 이미지 링크
        /// </summary>
        public string ImageUrl { get; init; }

        /// <summary>
        /// 종류
        /// </summary>
        public string Category { get; init; }

        /// <summary>
        /// 업그레이드 횟수
        /// </summary>
        public int Upgrade { get; init; }

        /// <summary>
        /// 기본 스탯
        /// </summary>
        public IDictionary<StatEnum, int> Base { get; init; }

        /// <summary>
        /// 작 스탯
        /// </summary>
        public IDictionary<StatEnum, int> Scroll { get; init; }
    }

    public record Equipment : EquipmentBase
    {
        /// <summary>
        /// 총 등급
        /// </summary>
        public PotentialGradeEnum Grade => (PotentialGradeEnum) Math.Max((int) (Potential?.Grade ?? 0), (int) (Additional?.Grade ?? 0));
        
        /// <summary>
        /// 스타포스
        /// </summary>
        public int Star { get; init; }

        /// <summary>
        /// 잠재능력
        /// </summary>
        public Potential Potential { get; init; }

        /// <summary>
        /// 에디셔널 잠재능력
        /// </summary>
        public Potential Additional { get; init; }

        /// <summary>
        /// 추가옵션
        /// </summary>
        public IDictionary<StatEnum, int> Flame { get; init; }

        /// <summary>
        /// 소울
        /// </summary>
        public KeyValuePair<StatEnum, int>? Soul { get; init; }
    }

    public record CashEquipment : EquipmentBase
    {
    }
}
