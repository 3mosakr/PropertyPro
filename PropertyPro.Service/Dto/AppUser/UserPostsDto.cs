using PropertyPro.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.AppUser
{
    public class UserPostsDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Sale { get; set; }
        public string Title { get; set; }
        public int UnitArea { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int Price { get; set; }

        public string Address { get; set; }
        public DateTime DatePosted { get; set; }

        public List<string> Images { get; set; }
    }
}
