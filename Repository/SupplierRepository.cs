using Azure.Core;
using CNLTHD.Data;
using CNLTHD.DTO;
using CNLTHD.Models;
using CNLTHD.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CNLTHD.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly CnlthdDbContext _context;
        public SupplierRepository(CnlthdDbContext context)
        {
            _context = context;
        }

      

        public async Task<bool> DeleteAsync(int supplierId)
        {
            var responseSupplier = await _context.Suppliers.Include(s=>s.Products).FirstOrDefaultAsync(item => item.SupplierId == supplierId);
            if (responseSupplier == null)
                return false;
            if (responseSupplier.Products.Count > 0)
                return false;
            _context.Suppliers.RemoveRange(responseSupplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Supplier> GetAsync(int supplierId)
        {

            var responseSupplier = await _context.Suppliers.FirstOrDefaultAsync(item => item.SupplierId == supplierId);
            return responseSupplier;
        }



        public async Task<SupplierDTO> UpdateAsync(int supplierId, UpdateSupplierDTO request)
        {
            var existingSupplier = await _context.Suppliers.FirstOrDefaultAsync(item => item.SupplierId == supplierId);
            if (existingSupplier != null)
            {
                existingSupplier.Address = request.Address;
                existingSupplier.Name = request.Name;
                existingSupplier.Email = request.Email;
                existingSupplier.Phone = request.Phone;
                await _context.SaveChangesAsync();
                return new SupplierDTO
                {
                    SupplierId = supplierId,
                    Name = request.Name,    
                    Email = request.Email,  
                    Phone = request.Phone,
                    Address = request.Address,
                };
            }
            return null;
            
        }

        public async Task<List<Supplier>> GetALlAsync()
        {
            var responseSuppliers = await _context.Suppliers.ToListAsync();
            var list = responseSuppliers.ToList();
            return list;
        }

        public async Task CreateAsync(Supplier request)
        {
            var result = await _context.Suppliers.AddAsync(request);
            await _context.SaveChangesAsync();
           
        }
    }
}
