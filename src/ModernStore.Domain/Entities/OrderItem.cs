using System;
using ModernStore.Shared.Entities;
using ModernStore.Shared.FluentValidator;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            Product = product.Id;
            Quantity = quantity;
            Price = product.Price;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 1);

            product.DecreaseQuantity(quantity);
        }

        public Guid Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
