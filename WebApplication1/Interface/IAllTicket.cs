using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IAllTicket
    {
        IEnumerable<Ticket> Tickets { get;}
        IEnumerable<Ticket> GetFavTicket { get; }
        Ticket GetObjectTicket(int ticketId);
    }
}
