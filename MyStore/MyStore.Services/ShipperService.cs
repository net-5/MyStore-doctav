using MyStore.Data;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services
{
    public interface IShipperService
    {
        List<Shippers> GetAllShippers();
        Shippers GetShippersById(int id);
        Shippers AddShipper(Shippers shipperToAdd);
        Shippers UpdateShipper(Shippers shipperToUpdate);
        bool IsUniqueName(string name);
    }
    public class ShipperService : IShipperService
    {
        private readonly IShippersRepository shipperRepository;

        public ShipperService(IShippersRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        public Shippers AddShipper(Shippers shipperToAdd)
        {
            if (IsUniqueName(shipperToAdd.Companyname))
            {
                var addedShipper = shipperRepository.AddShipper(shipperToAdd);
                return addedShipper;
            }
            else
            {
                return null;
            }
        }

        public List<Shippers> GetAllShippers()
        {
            return shipperRepository.GetAllShippers();
        }

        public Shippers GetShippersById(int id)
        {
            return shipperRepository.GetShipperById(id);
        }

        public bool IsUniqueName(string name)
        {
            return shipperRepository.IsUniqueName(name);
        }

        public Shippers UpdateShipper(Shippers shipperToUpdate)
        {
            return shipperRepository.UpdateShippers(shipperToUpdate);
        }
    }
}
