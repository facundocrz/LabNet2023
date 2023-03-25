using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ShippersLogic : BaseLogic, IABMLogic<Shippers, int>
    {
        public List<Shippers> GetAll()
        {
            return _northwindContext.Shippers.ToList();
        }

        public Shippers GetById(int id)
        {
            return _northwindContext.Shippers.FirstOrDefault(s => s.ShipperID == id);
        }

        public int GetLastId()
        {
            return this.GetAll().Last().ShipperID;
        }
        public void Add(Shippers shipper)
        {
            _northwindContext.Shippers.Add(shipper);
            _northwindContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var shipperToDelete = GetById(id);
            if (shipperToDelete != null)
            {
                _northwindContext.Shippers.Remove(shipperToDelete);
                _northwindContext.SaveChanges();
            }
            else
            {
                throw new NotFoundDBException();
            }
        }


        public void Update(Shippers shipper)
        {
            Shippers shipperToUpdate = this.GetById(shipper.ShipperID);
            if (shipperToUpdate != null)
            {
                shipperToUpdate.CompanyName = shipper.CompanyName;
                shipperToUpdate.Phone = shipper.Phone;
                _northwindContext.SaveChanges();
            }
            else
            {
                throw new NotFoundDBException();
            }
        }

    }
}
