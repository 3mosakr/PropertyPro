namespace PropertyPro.Data.Models
{
    public class Rating
    {
        // Composit pk (UserId, UnitId)
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public int RatingValue { get; set; }
        public DateTime RatingDate { get; set; }

        public User User { get; set; }
        public Unit Unit { get; set; }
    }
}
