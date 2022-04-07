using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;
using ProductApi.Data;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;

        }
        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToRemove = await _context.Products.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.Products.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Update(Product product)
        {
            var itemToUpdate = await _context.Products.FindAsync(product.ProductId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Name = product.Name;
            itemToUpdate.Price = product.Price;
            await _context.SaveChangesAsync();

        }
    }
}