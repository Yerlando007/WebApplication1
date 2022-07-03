namespace WebApplication1.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Ticket ticket { get; set; }
        public int price { get; set; }
        public string ShopCartId { get; set; }
    }
}
