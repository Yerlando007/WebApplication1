using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.mocks
{
    public class MockTicket : IAllTicket
    {
        private readonly ITicketCategory _categoryTicket = new MockCategory();
        public IEnumerable<Ticket> Tickets 
        {
            get
            {
                return new List<Ticket>
                {
                    new Ticket
                    {
                        Name = "Плохие парни",
                        ShortDesc = "Про авантюристов",
                        LongDesc = "Авантюристы начинают новую жизнь",
                        Price = 1100,
                        Img = "/img/badboys.jpg",
                        IsFavourite = true, 
                        available = true, 
                        Category = _categoryTicket.AllCategories.First()
                    },
                    new Ticket
                    {
                        Name = "Доктор Стрендж",
                        ShortDesc = "Про мага",
                        LongDesc = "Маг исправляет мультивселенную",
                        Price = 1500,
                        Img = "/img/maga.jpg",
                        IsFavourite = false,
                        available = false,
                        Category = _categoryTicket.AllCategories.Last()
                    },
                    new Ticket
                    {
                        Name = "Затерянный город",
                        ShortDesc = "Я хз, но там Ченнинг Таттум",
                        LongDesc = "Точно не могу дать описание. Посмотри в гугле",
                        Price = 900,
                        Img = "/img/city.jpg",
                        IsFavourite = true,
                        available = true,
                        Category = _categoryTicket.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Ticket> GetFavTicket { get; set; }

        public Ticket GetObjectTicket(int ticketId)
        {
            throw new NotImplementedException();
        }
    }
}
