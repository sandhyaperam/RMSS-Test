using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApplication.Areas.Admin.Models;
using InventoryApplication.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace InventoryApplication.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        BranchAccessLayer objCustomer = new BranchAccessLayer();
        [Area("Admin")]

        public ActionResult GetAllCountryDetails()
        {

            CountryViewModel EmpRepo = new CountryViewModel();
            ModelState.Clear();
            return View(EmpRepo.GetAllCountry());
        }
        // GET: Employee/AddEmployee   
        [Area("Admin")]
        public ActionResult AddCountry()
        {
            return View();
        }
        [Area("Admin")]
        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult AddCountry(CountryModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CountryViewModel EmpRepo = new CountryViewModel();

                    if (EmpRepo.AddCountry(Emp))
                    {
                        ViewBag.Message = "Country details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        [Area("Admin")]
        // GET: Employee/EditEmpDetails/5    
        public ActionResult EditCountryDetails(int id)
        {
            CountryViewModel EmpRepo = new CountryViewModel();



            return View(EmpRepo.GetAllCountry().Find(Emp => Emp.Id == id));

        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]
        [Area("Admin")]
        public ActionResult EditCountryDetails(int id, CountryModel obj)
        {
            try
            {
                CountryViewModel EmpRepo = new CountryViewModel();

                EmpRepo.UpdateCountry(obj);
                return RedirectToAction("GetAllCountryDetails");
            }
            catch
            {
                return View();
            }
        }
        [Area("Admin")]
        // GET: Employee/DeleteEmp/5    
        public ActionResult DeleteCountry(int id)
        {
            try
            {
                CountryViewModel EmpRepo = new CountryViewModel();
                if (EmpRepo.DeleteCountry(id))
                {
                    ViewBag.AlertMsg = "Country details deleted successfully";

                }
                return RedirectToAction("GetAllCountryDetails");

            }
            catch
            {
                return View();
            }
        }

    }
}