using CNLTHD.DTO;
using CNLTHD.Models;

namespace CNLTHD.Service.IService
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDTO>> GetAllAsync();
        Task<SupplierDTO> GetAsync(int supplierId);
        Task<SupplierDTO> UpdateAsync(int SupplierId, UpdateSupplierDTO request);
        Task<SupplierDTO> CreateAsync(CreateSupplierDTO request);
        Task<bool> DeleteAsync(int SupplierId);

    }
}
