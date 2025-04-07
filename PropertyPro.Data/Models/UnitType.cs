namespace PropertyPro.Data.Models
{
    /// <summary>
    /// Residential Real Estates: Apartments, villas, palaces, chalets.
    /// Commercial Real Estates: Administrative buildings, commercial centers, shops …, etc.
    /// </summary>
    public class UnitType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        //public ICollection<Unit> Units { get; set; }

    }
}
