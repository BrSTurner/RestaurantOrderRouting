using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROR.Orders.Domain.Enumerations;
using ROR.Orders.Domain.Models;

namespace ROR.Orders.Infra.Mappings
{
    public class OrderItemMapping : EntityMapping<OrderItem, int>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderItems");

            builder.Property(x => x.FinishDate).IsRequired(false);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.OrderStatus).HasDefaultValue(OrderStatusEnum.New).IsRequired();
            builder.Property(x => x.ItemId).IsRequired();
            builder.Property(x => x.ItemName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ItemPrice).IsRequired();
            builder.Property(x => x.Kitchen).IsRequired();
        }
    }
}
