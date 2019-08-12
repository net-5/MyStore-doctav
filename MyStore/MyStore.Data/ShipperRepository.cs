using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Data
{
    public interface IShippersRepository
    {
        List<Shippers> GetAllShippers();
        Shippers GetShipperById(int id);
        Shippers AddShipper(Shippers shipperToAdd);
        Shippers UpdateShippers(Shippers shipperToUpdate);
        bool IsUniqueName(string name);
    }

    public class ShipperRepository : IShippersRepository
    {
        private readonly StoreContext storeContext;

        public ShipperRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Shippers AddShipper(Shippers shipperToAdd)
        {
            var addedShipper = storeContext.Shippers.Add(shipperToAdd);
            storeContext.SaveChanges();
            return addedShipper.Entity;
        }

        public List<Shippers> GetAllShippers()
        {
            return storeContext.Shippers.ToList();
        }

        public Shippers GetShipperById(int id)
        {
            Shippers myShipper = storeContext.Shippers.Find(id);
            return myShipper;
        }

        public bool IsUniqueName(string name)
        {
            int nr = storeContext.Shippers.Count(x => x.Companyname == name);
            if (nr == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Shippers UpdateShippers(Shippers shipperToUpdate)
        {
            var updatedShipper = storeContext.Shippers.Update(shipperToUpdate);
            storeContext.SaveChanges();
            return updatedShipper.Entity;
        }
    }
}
