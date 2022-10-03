
namespace ApplicationCore.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? PictureUri { get; set; }

        public Product Product { get; set; } = null!;
    }
}
