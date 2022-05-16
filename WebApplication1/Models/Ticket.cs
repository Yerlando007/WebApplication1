namespace WebApplication1.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public bool IsFavourite { get; set; }
        public bool available { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
