namespace PropertyPro.Frontend.Models.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string UserType { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string? Photo { get; set; }
    }
}
