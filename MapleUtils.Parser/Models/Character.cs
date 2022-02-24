namespace MapleUtils.Parser.Models
{
    public record CharacterGeneralInformation
    {
        /// <summary>
        /// 캐릭터 이름
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 월드
        /// </summary>
        public string World { get; init; }

        /// <summary>
        /// 직업
        /// </summary>
        public string Job { get; init; }

        /// <summary>
        /// 레벨
        /// </summary>
        public int Level { get; init; }

        /// <summary>
        /// 캐릭터 이미지 url
        /// </summary>
        public string ImageUrl { get; init; }

        /// <summary>
        /// 성향
        /// </summary>
        public Traits Traits { get; init; }
    }

    public record Character : CharacterGeneralInformation
    {
        /// <summary>
        /// 장비 아이템
        /// </summary>
        public IList<Equipment> Equipments { get; init; }

        /// <summary>
        /// 기본 스펙
        /// </summary>
        public Spec Spec { get; init; }

        /// <summary>
        /// 아케인 심볼
        /// </summary>
        public IList<Symbol> Arcanes { get; init; }

        /// <summary>
        /// 어센틱 심볼
        /// </summary>
        public IList<Symbol> Authentics { get; init; }

        /// <summary>
        /// 펫 장비
        /// </summary>
        public IList<CashEquipment> PetEquipments { get; init; }

        /// <summary>
        /// 드래곤, 메카닉 장비
        /// </summary>
        public IList<EquipmentBase> OtherEquipments { get; init; }

        public Character() { }

        public Character(CharacterGeneralInformation generalInformation)
        {
            Name = generalInformation.Name;
            World = generalInformation.World;
            Job = generalInformation.Job;
            Level = generalInformation.Level;
            ImageUrl = generalInformation.ImageUrl;
            Traits = generalInformation.Traits;
        }
    }
}
