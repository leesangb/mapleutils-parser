using System.Text.Json.Serialization;

namespace MapleUtils.Parser.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PotentialGradeEnum
    {
        Nothing,
        Rare,
        Epic,
        Unique,
        Legendary,
        Special,
    }

    public static class PotentialGrade
    {
        public static PotentialGradeEnum Parse(string grade)
        {
            if (grade == null) return PotentialGradeEnum.Nothing;
            if (grade.Contains("레전드리")) return PotentialGradeEnum.Legendary;
            if (grade.Contains("유니크")) return PotentialGradeEnum.Unique;
            if (grade.Contains("에픽")) return PotentialGradeEnum.Epic;
            if (grade.Contains("레어")) return PotentialGradeEnum.Rare;
            if (grade.Contains("스페셜")) return PotentialGradeEnum.Special;
            return PotentialGradeEnum.Nothing;
        }
    }
}
