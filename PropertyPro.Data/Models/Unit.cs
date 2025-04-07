using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Data.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? StreetName { get; set; } // if category is property
        public string? CompoundName { get; set; } // if category is compound
        public int UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int Price { get; set; }
        
        public DateTime DatePosted { get; set; }

        public int UserId { get; set; } // Unit post owner (posted by)
        public int CategoryId { get; set; }
        public int UnitTypeId { get; set; }
        public int SaleTypeId { get; set; }
        
        public string? Address { get; set; }
        
        public int GovernorateId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }

        public string ResourceLink { get; set; }
        public string DeveloperPortfolio { get; set; }

        public User User { get; set; } // posted by
        public Category Category { get; set; }
        public UnitType UnitType { get; set; }
        public SaleType SaleType { get; set; }
        public Governorate Governorate { get; set; }
        public City City { get; set; } 
        public Area Area { get; set; }
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Image> Images { get; set; } = new List<Image>();

    }
}
