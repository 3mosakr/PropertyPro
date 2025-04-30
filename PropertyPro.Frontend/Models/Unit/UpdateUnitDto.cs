using Microsoft.AspNetCore.Components.Forms;

namespace PropertyPro.Frontend.Models.Unit
{
    public class UpdateUnitDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string? StreetName { get; set; }
        //public string? CompoundName { get; set; }
        public string Address { get; set; } = string.Empty;
        public int UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int Price { get; set; }
        public string? ResourceLink { get; set; }
        public string? DeveloperPortfolio { get; set; }
        public List<IBrowserFile> Image { get; set; } = new(); // الصور الجديدة
        public List<string> ExistingImages { get; set; } = new(); // روابط الصور القديمة
    }
}
