namespace PropertyPro.Data.Models
{
    public class City
    {
        public int Id { get; set; }
        public int GovernorateId { get; set; }
        public string CityName { get; set; }

        public Governorate Governorate { get; set; }
        public ICollection<Area> Areas { get; set; }
        //public ICollection<Unit> Units { get; set; }

    }
}
