using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage.Models;
using Garage.DAL;

namespace Garage.Controllers
{
    public class DriversController : Controller
    {
        private ICarRepository carRepository;
        private IDriverRepository driverRepository;

        public DriversController(ICarRepository carRepository, IDriverRepository driverRepository)
        {
            this.carRepository = carRepository;
            this.driverRepository = driverRepository;
        }

        public IActionResult Index()
        {
            DriverIndexViewModel model = new DriverIndexViewModel
            {
                Drivers = driverRepository.GetDrivers()
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            DriverDetailsViewModel model = new DriverDetailsViewModel
            {
                Name = driverRepository.GetDriverByID(id).Name,
                Age = driverRepository.GetDriverByID(id).Age,
                Cars = carRepository.GetCars().Where(car => car.DriverID == id)
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DriverID,Name,Age")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                driverRepository.InsertDriver(driver);
                driverRepository.Save();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        public IActionResult Edit(int id)
        {
            Driver driver = driverRepository.GetDriverByID(id);
            DriverEditViewModel model = new DriverEditViewModel
            {
                Name = driver.Name,
                Age = driver.Age,
                DriverID = driver.DriverID
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DriverEditViewModel model)
        {
            Driver driver = driverRepository.GetDriverByID(model.DriverID);
            driver.Name = model.Name;
            driver.Age = model.Age;
            driverRepository.UpdateDriver(driver);
            driverRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Driver driver = driverRepository.GetDriverByID(id);
            DriverDeleteViewModel model = new DriverDeleteViewModel
            {
                Name = driver.Name,
                Age = driver.Age,
                DriverID = driver.DriverID
            };
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DriverDeleteViewModel model)
        {
            driverRepository.DeleteDriver(model.DriverID);
            driverRepository.Save();
            return RedirectToAction("Index");
        }

        private bool DriverExists(int id)
        {
            return driverRepository.GetDrivers().Any(driver => driver.DriverID == id);
        }
    }
}
