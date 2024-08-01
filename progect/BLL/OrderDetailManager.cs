using DAL;

namespace BLL
{
    public class OrderDetailManager
    {
        private OrderDetail orderDetailsDAL = new OrderDetail();

        public void AddOrderDetail(int orderId, int cocktailId, int quantity)
        {
            orderDetailsDAL.AddOrderDetails(orderId, cocktailId, quantity);
        }
    }
}
