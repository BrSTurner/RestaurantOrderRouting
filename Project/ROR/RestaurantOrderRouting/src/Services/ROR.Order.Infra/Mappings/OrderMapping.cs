using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROR.Orders.Domain.Enumerations;
using ROR.Orders.Domain.Models;


namespace ROR.Orders.Infra.Mappings
{
    public class OrderMapping : EntityMapping<Order, int>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("Orders");

            builder.Property(x => x.OrderStatus).HasDefaultValue(OrderStatusEnum.New).IsRequired();
            builder.Property(x => x.OrderType).IsRequired();
            builder.Property(x => x.FinalPrice).IsRequired();
            builder.Property(x => x.FinishDate);
            builder.Property(x => x.TableNumber);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
