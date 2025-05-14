using Microsoft.AspNetCore.Components.Forms;

namespace PropertyPro.Frontend.Models.Unit
{
    public class AddUnitDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string StreetName { get; set; }
        public string CompoundName { get; set; }
        public double UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; } = 0; // Default value for UserId
        public int CategoryId { get; set; }
        public int UnitTypeId { get; set; }
        public int SaleTypeId { get; set; }
        public int GovernorateId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string ResourceLink { get; set; }
        // إضافة خاصية لتحديد إذا كانت الوحدة مميزة
        public bool IsFeatured { get; set; }
        public string DeveloperPortfolio { get; set; }

        //public List<IBrowserFile> Image { get; set; }

    }
}
