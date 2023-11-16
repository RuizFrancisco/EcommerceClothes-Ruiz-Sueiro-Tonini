using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public Product GetByName(string name);
        public void Add(ProductDTO productDTO);
        public void Update(int id, ProductDTO productDTO);
        public void Delete(int id);
    }
}
