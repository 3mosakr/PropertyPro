using Microsoft.AspNetCore.Identity;

namespace PropertyPro.Data.Models
{
    public class User : IdentityUser<int>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string? Photo { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public ICollection<Unit> Units { get; set; } // posts
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
