using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage.Models;

namespace Garage.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository carRepository;
        private IDriverRepository driverRepository;

        public CarsController(ICarRepository carRepository, IDriverRepository driverRepository)
        {
            this.carRepository = carRepository;
            this.driverRepository = driverRepository;
        }

        // GET: Cars
        public IActionResult Index()
        {
            CarIndexViewModel model = new CarIndexViewModel
            {
                Cars = carRepository.GetCars()
            };
            return View(model);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            CarCreateViewModel model = new CarCreateViewModel
            {
                Drivers = GetDrivers()
            };
            return View(model);
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarCreateViewModel model)
        {
            Car car = new Car
            {
                Manufacturer = model.Manufacturer,
                MOT = model.MOT,
                DriverID = model.SelectedDriverId
            };
            carRepository.InsertCar(car);
            carRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (CarExists(id))
            {
                Car car = carRepository.GetCarByID(id);
                Driver driver = driverRepository.GetDriverByID(car.DriverID);
                CarDetailsViewModel model = new CarDetailsViewModel
                {
                    Manufacturer = car.Manufacturer,
                    MOT = car.MOT,
                    Driver = driver.Name
                };
                return View(model);
            }
            else return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            Car car = carRepository.GetCarByID(id);
            CarEditViewModel model = new CarEditViewModel
            {
                Drivers = GetDrivers(),
                CarID = car.CarID,
                Manufacturer = car.Manufacturer,
                MOT = car.MOT
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarEditViewModel model)
        {
            Car car = carRepository.GetCarByID(model.CarID);
            car.Manufacturer = model.Manufacturer;
            car.MOT = model.MOT;
            car.DriverID = model.SelectedDriverId;
            carRepository.UpdateCar(car);
            carRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Car car = carRepository.GetCarByID(id);
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Car car = carRepository.GetCarByID(id);
            carRepository.DeleteCar(car.CarID);
            carRepository.Save();
            return RedirectToAction("Index");
        }

        private bool CarExists(int id)
        {
            return carRepository.GetCars().Any(car => car.CarID == id);
        }

        private IEnumerable<SelectListItem> GetDrivers()
        {
            var drivers = driverRepository.GetDrivers().Select(driver =>
                new SelectListItem
                {
                    Value = driver.DriverID.ToString(),
                    Text = driver.Name
                });
            return new SelectList(drivers, "Value", "Text");
        }
    }
}
