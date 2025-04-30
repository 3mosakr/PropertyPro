using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.Units
{
    public class AddUnitDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? StreetName { get; set; } 
        public string? CompoundName { get; set; } 
        public int UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int Price { get; set; }

        public int UserId { get; set; } = 0; // Unit post owner (posted by)
        public int CategoryId { get; set; }
        public int UnitTypeId { get; set; }
        public int SaleTypeId { get; set; }
        
        public int GovernorateId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string? ResourceLink { get; set; }
        public string? DeveloperPortfolio { get; set; }
        //public IFormFileCollection Image { get; set; }
        public List<IFormFile> Image { get; set; }
    }
}
