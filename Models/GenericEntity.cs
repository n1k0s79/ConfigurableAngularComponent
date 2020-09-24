namespace QualcoApp.Models
{
    public class GenericEntity
    {
        public virtual GenericEntitySummary ToSummary() => throw new System.Exception("Implement the ToSummary function in the derived class");
        public GenericEntityDescriptor GetDescriptor() => GenericEntityDescriptor.FromEntity(this);
    }
}
