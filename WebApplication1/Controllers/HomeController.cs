using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IAllTicket _tickRep;


        public HomeController(IAllTicket tickRep)
        {
            _tickRep = tickRep;
        }
        public ViewResult Index()
        {
            var homeTicket = new HomeViewModel
            {
                favCars = _tickRep.GetFavTicket
            };
            return View(homeTicket);
        }
    }
}
