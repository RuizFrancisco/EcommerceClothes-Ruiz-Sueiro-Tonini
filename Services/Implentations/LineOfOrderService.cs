using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;
using EcommerceClothes.Repositories.Interfaces;
using EcommerceClothes.Services.Interfaces;
using System;

namespace EcommerceClothes.Services.Implentations
{
    public class LineOfOrderService : ILineOfOrderService
    {
        private readonly DBContext.DBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ILineOfOrderRepository _lineOfOrderRepository;

        public LineOfOrderService(DBContext.DBContext dbContext, IMapper mapper, IOrderRepository orderRepository, ILineOfOrderRepository lineOfOrderRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _lineOfOrderRepository = lineOfOrderRepository;
        }

        public LineOfOrder GetLineOfOrder(int id)
        {
            var lineOfOrder = _lineOfOrderRepository.GetLineOfOrder(id);

            if (lineOfOrder != null)
            {
                _dbContext.Entry(lineOfOrder)
                    .Reference(lo => lo.Product)
                    .Load();
            }

            return lineOfOrder;
        }
        public void UpdateLineOfOrder(int lineOfOrderId, LineOfOrderDTO lineOfOrderDTO)
        {
            var lineOfOrder = _lineOfOrderRepository.GetLineOfOrder(lineOfOrderId);

            if (lineOfOrder != null)
            {
                _mapper.Map(lineOfOrderDTO, lineOfOrder);

                _dbContext.SaveChanges();
            }
        }

        public void AddLineOfOrder(int orderId, LineOfOrderDTO lineOfOrderDTO)
        {
            var order = _orderRepository.GetOrderById(orderId);

            if (order != null)
            {
                var lineOfOrder = _mapper.Map<LineOfOrder>(lineOfOrderDTO);
                lineOfOrder.Order = order;

                order.LinesOfOrder.Add(lineOfOrder);

                _dbContext.SaveChanges();
            }
        }

        public void DeleteLineOfOrder(int id)
        {
            _lineOfOrderRepository.DeleteLineOfOrder(id);
        }
    }
}
