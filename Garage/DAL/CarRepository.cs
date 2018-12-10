using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage.Models;

namespace Garage.DAL
{
    public class CarRepository : ICarRepository
    {
        private GarageContext context;

        public CarRepository(GarageContext context)
        {
            this.context = context;
        }

        public IEnumerable<Car> GetCars()
        {
            return context.Car.ToList();
        }

        public Car GetCarByID(int id)
        {
            return context.Car.Find(id);
        }

        public void InsertCar(Car car)
        {
            context.Car.Add(car);
        }

        public void DeleteCar(int CarID)
        {
            Car car = context.Car.Find(CarID);
            context.Car.Remove(car);
        }

        public void UpdateCar(Car car)
        {
            context.Entry(car).State = EntityState.Modified;
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
