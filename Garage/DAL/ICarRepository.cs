using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Models;

namespace Garage.DAL
{
    public interface ICarRepository : IDisposable
    {
        IEnumerable<Car> GetCars();
        Car GetCarByID(int id);
        void InsertCar(Car car);
        void DeleteCar(int id);
        void UpdateCar(Car car);
        void Save();
    }
}
