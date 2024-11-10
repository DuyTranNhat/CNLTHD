﻿using CNLTHD.DTO;
using CNLTHD.Models;
using CNLTHD.Repository.IRepository;
using CNLTHD.Service.IService;

namespace CNLTHD.Service
{
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDTO> CreateAsync(CreateSupplierDTO request)
        {
            var model = new Supplier
            {
                Address = request.Address,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,

            };

            await _supplierRepository.CreateAsync(model);

            return new SupplierDTO
            {
                Address = model.Address,
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                SupplierId = model.SupplierId
            };
        }

        public async Task DeleteAsync(int SupplierId)
        {
            await _supplierRepository.DeleteAsync(SupplierId);
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            var response = await _supplierRepository.GetALlAsync();
            return response;
        }

        public async Task<SupplierDTO> GetAsync(int SupplierId)
        {
            var response = await _supplierRepository.GetAsync(SupplierId);
            if (response == null) return null;
            return new SupplierDTO
            {
                SupplierId = response.SupplierId,
                Address = response.Address,
                Email = response.Email,
                Name = response.Name,
                Phone = response.Phone,
            };

        }

        public async Task<SupplierDTO> UpdateAsync(int SupplierId, UpdateSupplierDTO request)
        {
          var result =   await _supplierRepository.UpdateAsync(SupplierId, request);
            if (result != null)
            {
                return result;

            }
            return null;

        }


    }
}
