namespace PropertyPro.Data.Models
{
    public class Area
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string AreaName { get; set; }

        public City City { get; set; }
        //public ICollection<Unit> Units { get; set; }

    }
}
