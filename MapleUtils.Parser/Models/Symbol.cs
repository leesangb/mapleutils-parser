using MapleUtils.Parser.Constants;

namespace MapleUtils.Parser.Models
{
    public record Symbol
    {
        /// <summary>
        /// 심볼 이름
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 스탯 목록
        /// </summary>
        public IDictionary<StatEnum, int> Stat { get; init; }

        /// <summary>
        /// 레벨
        /// </summary>
        public int Level { get; init; }

        /// <summary>
        /// 현제 경험치
        /// </summary>
        public int Experience { get; init; }

        /// <summary>
        /// 레벨업에 필요한 경험치
        /// </summary>
        public int RequiredExperience { get; init; }
    }
}
