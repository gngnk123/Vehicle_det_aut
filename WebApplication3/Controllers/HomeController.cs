using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleDet.Models;
using DataLibrary;
using static DataLibrary.BusinessLogic.VehicleProcessor;

namespace VehicleDet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult ViewVehicles()
        {
            ViewBag.Message = "Vehicle List";

            var data = LoadVehicle();
            List<Vehiclemodel> vehicles = new List<Vehiclemodel>();

            foreach (var row in data)
            {
                vehicles.Add(new Vehiclemodel
                {
                    Id = row.Id,
                    CarId = row.CarId,
                    Make = row.Make,
                    C_Model = row.Model,
                    Year = row.Year,
                    Odo = row.Odo,
                    Color = row.Color,
                    Engine = row.Engine,
                    
                });
            }
      
            return View(vehicles);
        }
        [Authorize (Roles ="Admin")]
        public ActionResult CarAdd()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarAdd(Vehiclemodel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateVehicle(
                    model.CarId,
                    model.Make,
                    model.C_Model,
                    model.Year,
                    model.Odo,
                    model.Color,
                    model.Engine);
                return RedirectToAction("ViewVehicles");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CarDelete(int Id)
        {
            var data = SelectVehicle(Id);
            Vehiclemodel vehicles = new Vehiclemodel();

            foreach (var item in data)
            {
                vehicles.Id = item.Id;
                vehicles.CarId = item.CarId;
                vehicles.Make = item.Make;
                vehicles.C_Model = item.Model;
                vehicles.Year = item.Year;
                vehicles.Odo = item.Odo;
                vehicles.Color = item.Color;
                vehicles.Engine = item.Engine;
                
            }
            return View(vehicles);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CarDelete(int Id, Vehiclemodel model)
        {

                var data = DeleteVehicle(
                    model.Id);

                return RedirectToAction("ViewVehicles");

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CarUpdate(int Id)
        {
            var data = SelectVehicle(Id);
            Vehiclemodel vehicles = new Vehiclemodel();

            foreach (var item in data)
            {
                vehicles.Id = item.Id;
                vehicles.CarId = item.CarId;
                vehicles.Make = item.Make;
                vehicles.C_Model = item.Model;
                vehicles.Year = item.Year;
                vehicles.Odo = item.Odo;
                vehicles.Color = item.Color;
                vehicles.Engine = item.Engine;

            }
            return View(vehicles);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CarUpdate(int Id, Vehiclemodel model)
        {
            if (ModelState.IsValid)
            {
                var recordsCreated = UpdateVehicle(
                    model.Id,
                    model.CarId,
                    model.Make,
                    model.C_Model,
                    model.Year,
                    model.Odo,
                    model.Color,
                    model.Engine);
                return RedirectToAction("ViewVehicles");
            }

            return RedirectToAction("ViewVehicles");

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult DeletedView()
        {
            ViewBag.Message = "Vehicle List";

            var data = LoadDeletedVehicle();
            List<Vehiclemodel> vehicles = new List<Vehiclemodel>();

            foreach (var row in data)
            {
                vehicles.Add(new Vehiclemodel
                {
                    Id = row.Id,
                    CarId = row.CarId,
                    Make = row.Make,
                    C_Model = row.Model,
                    Year = row.Year,
                    Odo = row.Odo,
                    Color = row.Color,
                    Engine = row.Engine
                });
            }

            return View(vehicles);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CarRecover(int Id)
        {
            var data = SelectVehicle(Id);
            Vehiclemodel vehicles = new Vehiclemodel();

            foreach (var item in data)
            {
                vehicles.Id = item.Id;
                vehicles.CarId = item.CarId;
                vehicles.Make = item.Make;
                vehicles.C_Model = item.Model;
                vehicles.Year = item.Year;
                vehicles.Odo = item.Odo;
                vehicles.Color = item.Color;
                vehicles.Engine = item.Engine;

            }
            return View(vehicles);
        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CarRecover(int Id, Vehiclemodel model)
        {

            var data = RecoverVehicle(
                model.Id);

            return RedirectToAction("ViewVehicles");

        }




    }
}