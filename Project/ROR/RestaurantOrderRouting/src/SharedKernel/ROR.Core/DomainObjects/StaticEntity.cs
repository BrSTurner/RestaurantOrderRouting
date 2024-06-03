namespace ROR.Core.DomainObjects
{
    public class StaticEntity<T> : Entity<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
