
namespace QualcoApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string CatalogueNr { get; set; }
        public string Description { get; set; }

        public string Unit{ get; set; }
        public decimal UnitPrice { get; set; }
    }
}
