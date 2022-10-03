
namespace ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public string BuyerId { get; set; } = null!;
        public Adress ShippingAdress { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
