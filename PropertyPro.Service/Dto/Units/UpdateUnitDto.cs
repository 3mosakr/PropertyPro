using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.Units
{
    public class UpdateUnitDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string? StreetName { get; set; } 
        //public string? CompoundName { get; set; } 
        public int UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int Price { get; set; }

        public string? ResourceLink { get; set; }
        public string? DeveloperPortfolio { get; set; }

        public List<IFormFile>? Image { get; set; }

    }
}
