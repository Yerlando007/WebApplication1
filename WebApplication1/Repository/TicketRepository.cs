using Microsoft.EntityFrameworkCore;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class TicketRepository : IAllTicket
    {
        private readonly AppDBContent appDBContent;
        public TicketRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Ticket> Tickets => appDBContent.Ticket.Include(c => c.Category);
        public IEnumerable<Ticket> GetFavTicket => appDBContent.Ticket.Where(p => p.IsFavourite).Include(c => c.Category);
        public Ticket GetObjectTicket(int ticketId) => appDBContent.Ticket.FirstOrDefault(p => p.Id == ticketId);
    }
}
