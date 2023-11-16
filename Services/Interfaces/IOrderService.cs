using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetOrdersByClientId(int clientId);
        Order GetOrderById(int id);
        public void AddOrder(OrderDTO orderDTO);
        void DeleteOrder(int id);
    }
}
