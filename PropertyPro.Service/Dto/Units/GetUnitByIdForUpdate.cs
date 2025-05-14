

namespace PropertyPro.Service.Dto.Units
{
    public class GetUnitByIdForUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? StreetName { get; set; }
        public string? CompoundName { get; set; }
        public int UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int Price { get; set; }
        public string? ResourceLink { get; set; }
        public string? DeveloperPortfolio { get; set; }
        // إضافة خاصية لتحديد إذا كانت الوحدة مميزة
        public bool IsFeatured { get; set; }
        public List<string> Images { get; set; }
    }
}
