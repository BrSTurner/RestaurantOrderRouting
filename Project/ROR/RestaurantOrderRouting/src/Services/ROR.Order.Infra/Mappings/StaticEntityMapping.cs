using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROR.Core.DomainObjects;

namespace ROR.Orders.Infra.Mappings
{
    public abstract class StaticEntityMapping<TEntity, TType> : EntityMapping<TEntity, TType> where TEntity : StaticEntity<TType>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        }
    }
}
