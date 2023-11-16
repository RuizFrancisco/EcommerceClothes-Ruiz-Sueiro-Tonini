using EcommerceClothes.Entities;
using EcommerceClothes.Repositories.Interfaces;

namespace EcommerceClothes.Repositories.Implementations
{
    public class LineOfOrderRepository : Repository, ILineOfOrderRepository
    {
        public LineOfOrderRepository(DBContext.DBContext context) : base(context) 
        {
       
        }

        public LineOfOrder GetLineOfOrder(int id)
        {
            return _context.LinesOfOrder.Find(id);
        }

        public void AddLineOfOrder(LineOfOrder line)
        {
            _context.Add(line);
            _context.SaveChanges();
        }

        public void DeleteLineOfOrder(int id)
        {
            _context.LinesOfOrder.Remove(GetLineOfOrder(id));
            _context.SaveChanges();
        } 

        public void UpdateLineOfOrder(LineOfOrder line)
        {
            _context.Update(line);
            _context.SaveChanges();
        }
    }
}
