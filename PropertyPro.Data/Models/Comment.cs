using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }

        public Unit Unit { get; set; }
        public User User { get; set; }
         

    }
}
