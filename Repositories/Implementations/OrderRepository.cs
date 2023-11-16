using EcommerceClothes.Entities;
using EcommerceClothes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcommerceClothes.Repositories.Implementations
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(DBContext.DBContext context) : base(context)
        {
        }
        public IQueryable<Order> GetAll()
        {
            return _context.Orders;
        }
        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }
        public IQueryable<Order> GetOrdersByClientId(int clientId)
        {
            return _context.Orders.Where(x => x.ClientId == clientId);
        }
        public void AddOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            var order = GetOrderById(id);

            if (order != null)
            {
                
                _context.LinesOfOrder.RemoveRange(order.LinesOfOrder);

                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
        public Order IncludeOrderDetails(Order order)
        {
            return _context.Orders
                .Include(s => s.Client)
                .Include(s => s.LinesOfOrder)
                    .ThenInclude(sl => sl.Product)
                .FirstOrDefault(s => s.Id == order.Id);
        }
    }
}
