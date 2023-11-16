using EcommerceClothes.Entities;

namespace EcommerceClothes.Repositories.Interfaces
{
    public interface ILineOfOrderRepository
    {
        public LineOfOrder GetLineOfOrder(int id);
        public void AddLineOfOrder(LineOfOrder line);
        public void UpdateLineOfOrder(LineOfOrder line);
        public void DeleteLineOfOrder(int id);
    }
}
