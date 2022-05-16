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
        public ViewResult List()
        {
            //ViewBag.Category = "Что-то";
            TicketListViewModel obj = new TicketListViewModel();
            obj.GetAllTicket = _allTickets.Tickets;
            obj.currCategory = "Билеты";
            //var cars = _allTickets.Tickets;
            return View(obj);
        }
        
        public ViewResult Buy()
        {
            @ViewBag.Category = "Что-то";
            return View();
        }
    }
}