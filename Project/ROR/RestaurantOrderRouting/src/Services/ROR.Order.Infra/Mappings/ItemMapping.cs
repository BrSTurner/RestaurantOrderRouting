using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROR.Orders.Domain.Models;

namespace ROR.Orders.Infra.Mappings
{
    public class ItemMapping : StaticEntityMapping<Item, int>
    {
        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            base.Configure(builder);

            builder.ToTable("Items");

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Kitchen).IsRequired();

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId);
        }
    }
}
