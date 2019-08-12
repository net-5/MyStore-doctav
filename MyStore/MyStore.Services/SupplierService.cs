using MyStore.Data;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        bool IsUniqueName(string name);
        List<Suppliers> GetAllSuppliers();
        Suppliers GetSupplierById(int id);
        Suppliers Add(Suppliers supplierToAdd);
        Suppliers Update(Suppliers supplierToUpdate);

    }
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Suppliers Add(Suppliers supplierToAdd)
        {
            Suppliers addedSupplier = supplierRepository.AddSupplier(supplierToAdd);
            return addedSupplier;
        }

        public List<Suppliers> GetAllSuppliers()
        {
            List<Suppliers> allSuppliers;
            allSuppliers = supplierRepository.GetAllSuppliers();
            return allSuppliers;
        }

        public Suppliers GetSupplierById(int id)
        {
            Suppliers mySupplier;
            mySupplier = supplierRepository.GetSupplierById(id);
            return mySupplier;
        }

        public bool IsUniqueName(string name)
        {
            return supplierRepository.IsUniqueName(name);
        }

        public Suppliers Update(Suppliers supplierToUpdate)
        {
            Suppliers updatedSupplier;
            updatedSupplier = supplierRepository.UpdateSupplier(supplierToUpdate);
            return updatedSupplier;
        }
    }
}
