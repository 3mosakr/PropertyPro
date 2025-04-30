using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.Auth
{
    public class AddRoleModel
    {
        public required int UserId { get; set; }
        public required int Role { get; set; }
    }
}
