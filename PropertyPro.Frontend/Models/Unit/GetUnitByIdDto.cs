namespace PropertyPro.Frontend.Models.Unit
{
    public class GetUnitByIdDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Sale { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; } // Unit post owner (posted by)

        public string? ResourceLink { get; set; }
        public string? DeveloperPortfolio { get; set; }
        // إضافة خاصية لتحديد إذا كانت الوحدة مميزة
        public bool IsFeatured { get; set; }
        public List<string> Images { get; set; }
    }
}
