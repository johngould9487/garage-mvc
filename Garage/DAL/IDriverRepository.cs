using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Models;

namespace Garage.DAL
{
    public interface IDriverRepository : IDisposable
    {
        IEnumerable<Driver> GetDrivers();
        Driver GetDriverByID(int id);
        void InsertDriver(Driver driver);
        void DeleteDriver(int id);
        void UpdateDriver(Driver driver);
        void Save();
    }
}
