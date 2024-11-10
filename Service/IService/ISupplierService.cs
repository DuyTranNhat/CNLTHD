using CNLTHD.DTO;
using CNLTHD.Models;

namespace CNLTHD.Service.IService
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllAsync();
        Task<SupplierDTO> GetAsync(int supplierId);
        Task<SupplierDTO> UpdateAsync(int SupplierId, UpdateSupplierDTO request);
        Task<SupplierDTO> CreateAsync(CreateSupplierDTO request);
        Task DeleteAsync(int SupplierId);

    }
}
