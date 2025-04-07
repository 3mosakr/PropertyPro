namespace PropertyPro.Data.Models
{
    public class Favorite
    {
        public Favorite(int userId, int unitId)
        {
            UserId = userId;
            UnitId = unitId;
        }

        // Composite pk (UserId, UnitId)
        public int UserId { get; set; }
        public int UnitId { get; set; }

        public User User { get; set; }
        public Unit Unit { get; set; }

        
    }
}
