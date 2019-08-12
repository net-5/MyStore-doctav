using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        bool IsUniqueName(string name);
        List<Suppliers> GetAllSuppliers();
        Suppliers GetSupplierById(int id);
        Suppliers AddSupplier(Suppliers supplierToAdd);
        Suppliers UpdateSupplier(Suppliers supplierToUpdate);
    }
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext storeContext;

        public SupplierRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Suppliers AddSupplier(Suppliers supplierToAdd)
        {
            var addedSupplier = storeContext.Suppliers.Add(supplierToAdd);
            storeContext.SaveChanges();
            return addedSupplier.Entity;
        }

        public List<Suppliers> GetAllSuppliers()
        {
            return storeContext.Suppliers.ToList();
        }

        public Suppliers GetSupplierById(int id)
        {
            Suppliers mySupplier = storeContext.Suppliers.Find(id);
            return mySupplier;
        }

        public bool IsUniqueName(string name)
        {
            int nr = storeContext.Suppliers.Count(x => x.Companyname == name);
            if (nr==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Suppliers UpdateSupplier(Suppliers supplierToUpdate)
        {
            var updatedSupplier = storeContext.Suppliers.Update(supplierToUpdate);
            storeContext.SaveChanges();
            return updatedSupplier.Entity;
        }
    }
}
