using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class TicketListViewModel
    {
        public IEnumerable<Ticket> GetAllTicket { get; set; }
        public string currCategory { get; set; }
    }
}
