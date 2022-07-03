using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Interface;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TicketController : Controller
    {
        private readonly IAllTicket _allTickets;
        private readonly ITicketCategory _allCategories;

        public TicketController(IAllTicket iAllTicket, ITicketCategory iTicketCategory)
        {
            _allTickets = iAllTicket;
            _allCategories = iTicketCategory;
        }
        [Route("Ticket/List")]
        [Route("Ticket/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Ticket> tickets = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                tickets = _allTickets.Tickets.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("vita", category, StringComparison.OrdinalIgnoreCase))
                {
                    tickets = _allTickets.Tickets.Where(i => i.Category.CategoryName.Equals("PSVita")).OrderBy(i => i.Id);
                }
                else if (string.Equals("p3s", category, StringComparison.OrdinalIgnoreCase))
                {
                    tickets = _allTickets.Tickets.Where(i => i.Category.CategoryName.Equals("PS3")).OrderBy(i => i.Id);
                }
                else if (string.Equals("p4s", category, StringComparison.OrdinalIgnoreCase))
                {
                    tickets = _allTickets.Tickets.Where(i => i.Category.CategoryName.Equals("PS4")).OrderBy(i => i.Id);
                }
                currCategory = _category;
            }
            var tickObj = new TicketListViewModel
            {
                GetAllTicket = tickets, 
                currCategory = "Игры"
            };
            ViewBag.Title = "Страница с играми";
            return View(tickObj);
        }
    }
}