using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;
using EcommerceClothes.Repositories.Interfaces;
using EcommerceClothes.Services.Interfaces;

namespace EcommerceClothes.Services.Implentations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByName(string name)
        {
            return _productRepository.GetByName(name);
        }

        public void Add(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productRepository.Add(product);
        }

        public void Update(int id, ProductDTO productDTO)
        {
            var existingProduct = _productRepository.GetById(id);

            if (existingProduct == null)
            {
                throw new Exception("Producto no encontrado");
            }

            existingProduct.Name = productDTO.Name;
            existingProduct.Description = productDTO.Description;
            existingProduct.Price = productDTO.Price;

            _productRepository.Update(existingProduct);
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
