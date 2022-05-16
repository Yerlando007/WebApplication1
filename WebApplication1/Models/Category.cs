namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
