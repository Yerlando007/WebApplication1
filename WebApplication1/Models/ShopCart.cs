using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartid = session.GetString("Cartid") ?? Guid.NewGuid().ToString();
            session.SetString("Cartid", shopCartid);
            return new ShopCart(context) { ShopCartId = shopCartid };
        }

            public void AddtoCart(Ticket ticket)
            {
                appDBContent.ShopCartItem.Add(new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    ticket = ticket,
                    price = ticket.Price,


                });
                appDBContent.SaveChanges();
            }
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.ticket).ToList();
        }
    }
}
