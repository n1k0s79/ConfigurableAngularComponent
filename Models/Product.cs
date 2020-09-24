
namespace QualcoApp.Models
{
    [ListActions("Add,Edit,Delete")]
    [EntityActions("Edit,SalesReport,SalesForecast")]
    public class Product : GenericEntity
    {
        public int Id { get; set; }
        public string CatalogueNr { get; set; }
        public string Description { get; set; }

        public string Unit{ get; set; }
        public decimal UnitPrice { get; set; }

        public override GenericEntitySummary ToSummary() => new GenericEntitySummary() { Id = Id, Description = $"{CatalogueNr} {Description} ({Unit})" };
    }
}
