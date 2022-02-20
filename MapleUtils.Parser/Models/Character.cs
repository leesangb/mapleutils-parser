namespace MapleUtils.Parser.Models
{
    public record Character
    {
        public string Name { get; init; };
        public string World { get; init; }
        public string Job { get; init; }
        public int Level { get; init; }
        public string ImageUrl { get; init; }
        public IList<Equipment> Equipments { get; init; }
        public Spec Spec { get; init; }
        public IList<Symbol> Arcanes { get; init; }
        public IList<Symbol> Authentics { get; init; }
        public Traits Traits { get; init; }
        public IList<CashEquipment> PetEquipments { get; init; }
    }
}
