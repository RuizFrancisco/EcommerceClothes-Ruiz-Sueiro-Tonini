using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;
using EcommerceClothes.Repositories.Interfaces;
using EcommerceClothes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClothes.Services.Implentations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ILineOfOrderRepository _lineOfOrderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, ILineOfOrderRepository lineOfOrderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _lineOfOrderRepository = lineOfOrderRepository;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _orderRepository.GetAll()
                .Include(o => o.Client)
                .Select(o => new Order
                {
                    Id = o.Id,

                    Client = new Client
                    {
                        Id = o.Client.Id,
                        UserName = o.Client.UserName,
                    },

                    LinesOfOrder = o.LinesOfOrder.Select(lo => new LineOfOrder
                    {
                        Id = lo.Id,
                        Quantity = lo.Quantity,
                        ProductId = lo.ProductId,

                        Product = new Product
                        {
                            Id = lo.Product.Id,
                            Name = lo.Product.Name,
                            Price = lo.Product.Price,
                            Description = lo.Product.Description
                        },
                        TotalPrice = (float)(lo.Quantity * lo.Product.Price)

                    }).ToList(),
                    TotalPrice = o.LinesOfOrder.Sum(lo => (float)(lo.Quantity * lo.Product.Price))
                }).ToList();

            return orders;
        }
        public Order GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (order != null)
            {
                _orderRepository.IncludeOrderDetails(order);
                order.TotalPrice = order.LinesOfOrder.Sum(o => (float)(o.Quantity * o.Product.Price));
            }

            return order;
        }

        public IEnumerable<Order> GetOrdersByClientId(int clientId)
        {
            var orders = _orderRepository.GetOrdersByClientId(clientId)
                .Include(o => o.Client)
                .Include(o => o.LinesOfOrder)
                    .ThenInclude(lo => lo.Product)
                .ToList();

            orders.ForEach(o =>
            {
                o.TotalPrice = o.LinesOfOrder.Sum(lo => (float)(lo.Quantity * lo.Product.Price));
            });

            return orders;
        }
        public void AddOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _orderRepository.AddOrder(order);
        }


        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
    }
}
