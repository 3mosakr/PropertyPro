using PropertyPro.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.Favorites
{
    public class FavoriteDto
    {
        public int UnitId { get; set; }
        public string Title { get; set; }
        public string UnitType { get; set; }
        public int Price { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public string Address { get; set; }
        public bool IsFeatured { get; set; }
        public List<string> Images { get; set; }
    }
}
