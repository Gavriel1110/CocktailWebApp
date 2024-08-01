using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class OrderManager
    {
        private Order orderDAL = new Order();
        private OrderDetail orderDetailDAL = new OrderDetail();

        public List<Order> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return orderDAL.GetOrdersByUserId(userId);
        }

        public void PlaceOrder(int userId, int cocktailId, int quantity)
        {
            int orderId = orderDAL.AddOrder(userId);
            orderDetailDAL.AddOrderDetails(orderId, cocktailId, quantity);
        }

        public void DeleteOrder(int orderId)
        {
            orderDAL.DeleteOrder(orderId);
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            orderDAL.UpdateOrderStatus(orderId, status);
        }
    }
}
