using EcommerceClothes.Repositories.Interfaces;

namespace EcommerceClothes.Repositories.Implementations
{
    public class Repository : IRepository
    {
        internal readonly DBContext.DBContext _context; 

        public Repository(DBContext.DBContext context) 
        {
            this._context = context;
        }

        public bool SaveChanges() 
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
