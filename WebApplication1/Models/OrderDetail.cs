namespace WebApplication1.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int orderID { get; set; }
        public int ticketID { get; set; }
        public int price { get; set; }
        public virtual Ticket ticket { get; set; }
        public virtual Order order { get; set; }
    }
}
