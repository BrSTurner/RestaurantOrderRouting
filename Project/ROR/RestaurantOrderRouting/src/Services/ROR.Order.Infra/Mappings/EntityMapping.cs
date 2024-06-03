using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROR.Core.DomainObjects;
using System;

namespace ROR.Orders.Infra.Mappings
{
    public abstract class EntityMapping<TEntity, TType> : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TType>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Ignore(x => x.Notifications);
        }
    }
}
