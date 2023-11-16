using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Services.Interfaces
{
    public interface ILineOfOrderService
    {
        public LineOfOrder GetLineOfOrder(int id);
        public void AddLineOfOrder(int orderId, LineOfOrderDTO lineDTO);
        public void UpdateLineOfOrder(int lineOfOrderId, LineOfOrderDTO lineDTO);
        public void DeleteLineOfOrder(int id);
    }
}
