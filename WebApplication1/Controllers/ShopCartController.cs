using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;
using WebApplication1.Interface;

namespace WebApplication1.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllTicket _gameRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllTicket gameRep, ShopCart shopCart)
        {
            _gameRep = gameRep; 
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }
        public RedirectToActionResult addtoCart(int id)
        {
            var item = _gameRep.Tickets.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddtoCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
