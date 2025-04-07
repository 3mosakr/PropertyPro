using PropertyPro.Data.Models;
using PropertyPro.Service.Dto.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.AppUser
{
    public class UserFavoritsDto
    {
        public int UserId { get; set; }
        public int UnitId { get; set; }


        //public int Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Sale { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public string Address { get; set; }
        public DateTime DatePosted { get; set; }

        public string User { get; set; }
        public string UserPhone { get; set; }

        public List<string> Images { get; set; }
    }
}
