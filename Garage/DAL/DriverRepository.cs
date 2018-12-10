using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage.Models;

namespace Garage.DAL
{
    public class DriverRepository : IDriverRepository
    {
        private GarageContext context;

        public DriverRepository(GarageContext context)
        {
            this.context = context;
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return context.Driver.ToList();
        }

        public Driver GetDriverByID(int id)
        {
            return context.Driver.Find(id);
        }

        public void InsertDriver(Driver driver)
        {
            context.Driver.Add(driver);
        }

        public void DeleteDriver(int DriverID)
        {
            Driver driver = context.Driver.Find(DriverID);
            context.Driver.Remove(driver);
        }

        public void UpdateDriver(Driver driver)
        {
            context.Entry(driver).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
