using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Repositories
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();
        List<Customers> GetAllCustomers(string country, string name);
        Customers GetCustomerById(int id);
        Customers Update(Customers customerToUpdate);
        Customers AddCustomer(Customers customerToBeAdded);
        bool IsUniqueCompanyName(string name);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext storeContext;

        public CustomerRepository(StoreContext store)
        {
            storeContext = store;
        }

        public List<Customers> GetAllCustomers()
        {
            return storeContext.Customers.ToList();
        }

        public List<Customers> GetAllCustomers(string country, string name)
        {
            return storeContext.Customers
                .Where(x => x.Country == country && x.Contactname == name)
                .ToList();
        }

        public Customers GetCustomerById(int id)
        {
            return storeContext.Customers.Find(id);
        }

        public Customers Update(Customers customerToUpdate)
        {
            var updatedEntity = storeContext.Customers.Update(customerToUpdate);
            storeContext.SaveChanges();
            return updatedEntity.Entity;
        }

        public Customers AddCustomer(Customers customerToBeAdded)
        {
            var addedEntity = storeContext.Customers.Add(customerToBeAdded);
            storeContext.SaveChanges();
            return addedEntity.Entity;
        }

        public bool IsUniqueCompanyName(string name)
        {
            int nr = storeContext.Customers.Count(x => x.Companyname == name);
            if(nr==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
