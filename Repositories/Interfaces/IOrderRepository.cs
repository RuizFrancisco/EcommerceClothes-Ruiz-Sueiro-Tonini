using EcommerceClothes.Entities;

namespace EcommerceClothes.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        IQueryable<Order> GetOrdersByClientId(int clientId);
        Order GetOrderById(int id);
        void AddOrder(Order sale);
        void DeleteOrder(int id);
        Order IncludeOrderDetails(Order sale);
    }
}
