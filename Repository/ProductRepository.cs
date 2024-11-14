using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNLTHD.Data;
using CNLTHD.Models;
using CNLTHD.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CNLTHD.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CnlthdDbContext _context;

        public ProductRepository(CnlthdDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var rs = await _context.Products.Include(p => p.Category).
                Include(p => p.Supplier).ToListAsync();
            return rs;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var productByID = await _context.Products.Include("Category").Include("Supplier").
                FirstOrDefaultAsync(p => p.ProductId == id);

            return productByID;
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}