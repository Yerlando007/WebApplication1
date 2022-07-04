using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ticketID = el.ticket.Id,
                    orderID = order.Id,
                    price = el.ticket.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
