using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Dto.Comments
{
    public class AddCommentDto
    {
        //public int UserId { get; set; }
        public int UnitId { get; set; }
        public string Content { get; set; }
    }
}
