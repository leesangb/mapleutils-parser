using MapleUtils.Parser.Constants;

namespace MapleUtils.Parser.Models
{
    public record Potential
    {
        public string Grade { get; init; }
        public IList<KeyValuePair<StatEnum, int>> Effects { get; init; }
    }
    public abstract record EquipmentBase
    {
        public string Name { get; init; }
        public string ImageUrl { get; init; }
        public string Category { get; init; }
        public int Upgrade { get; init; }
        public IDictionary<StatEnum, int> Base { get; init; }
        public IDictionary<StatEnum, int> Scroll { get; init; }
    }

    public record Equipment : EquipmentBase
    {
        public string Grade { get; init; }
        public int Star { get; init; }
        public Potential Potential { get; init; }
        public Potential Additional { get; init; }
        public IDictionary<StatEnum, int> Flame { get; init; }
        public KeyValuePair<StatEnum, int>? Soul { get; init; }
    }

    public record CashEquipment : EquipmentBase
    {
    }
}
