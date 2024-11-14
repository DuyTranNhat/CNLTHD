using CNLTHD.DTO;
using CNLTHD.Models;

namespace CNLTHD.Repository.IRepository
{
    public interface ISupplierRepository
    {
        //create supplier 
        Task<Supplier> GetAsync(int SupplierId);
        Task<List<Supplier>> GetALlAsync();
        Task CreateAsync(Supplier request);
        Task<SupplierDTO> UpdateAsync( int SupplierId,UpdateSupplierDTO request);
        Task<bool> DeleteAsync(int id);

    }
}
