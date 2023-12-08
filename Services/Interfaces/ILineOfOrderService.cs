using EcommerceClothes.Entities;

namespace EcommerceClothes.Services.Interfaces
{
    public interface ILineOfOrderService
    {
        List<LineOfOrder> GetAllBySaleOrder(int orderId);
        LineOfOrder? GetOne(int Id);
        LineOfOrder CreateSaleOrderLine(LineOfOrder lineOfOrder);
        LineOfOrder UpdateSaleOrderLine(LineOfOrder lineOfOrder);
        void DeleteSaleOrderLine(int id);
        List<LineOfOrder> GetAllByProduct(int productId);
    }
}
