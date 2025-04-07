namespace PropertyPro.Data.Models
{
    public class Governorate
    {
        public int Id { get; set; }
        public string GovernorateName { get; set; }
        public ICollection<City> Citys { get; set; }
        //public ICollection<Unit> Units { get; set; }

    }
}
