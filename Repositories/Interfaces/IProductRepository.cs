using EcommerceClothes.Entities;

namespace EcommerceClothes.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public Product GetByName(string name);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(int id);
    }
}
