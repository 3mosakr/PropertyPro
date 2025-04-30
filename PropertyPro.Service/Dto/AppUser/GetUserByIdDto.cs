using PropertyPro.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.AppUser
{
    public class GetUserByIdDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string UserType { get; set; }
        public string? Photo { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }



    }
}
