using Microsoft.AspNetCore.Components.Forms;

namespace PropertyPro.Frontend.Models.User
{
    public class AddUserDto
    {
        public IBrowserFile? Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int UserTypeId { get; set; }
    }
}
