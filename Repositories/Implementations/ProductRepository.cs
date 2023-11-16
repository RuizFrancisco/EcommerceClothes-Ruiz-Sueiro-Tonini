﻿using EcommerceClothes.Entities;
using EcommerceClothes.Repositories.Interfaces;

namespace EcommerceClothes.Repositories.Implementations
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(DBContext.DBContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product GetByName(string name)
        {
            return _context.Products.SingleOrDefault(p => p.Name == name);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Products.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
