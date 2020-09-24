namespace QualcoApp.Models
{
    [ListActions("Add,Remove")]
    [EntityActions("Edit,Print,Invoice")]
    public class Customer : GenericEntity
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Street{ get; set; }
        public string HouseNumber{ get; set; }
        public string City{ get; set; }
        public string PostalCode{ get; set; }

        public override GenericEntitySummary ToSummary() => new GenericEntitySummary() { Id = Id, Description = $"{Lastname} {Firstname}" };
    }
}
