using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApplication.Areas.Admin.Models;
using InventoryApplication.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApplication.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        BranchAccessLayer objCustomer = new BranchAccessLayer();
        [Area("Admin")]

        public ActionResult GetAllEmpDetails()
        {

            BranchViewModel EmpRepo = new BranchViewModel();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }
        // GET: Employee/AddEmployee 
        [Area("Admin")]
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [Area("Admin")]
        [HttpPost]
        public ActionResult AddEmployee(BranchModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BranchViewModel EmpRepo = new BranchViewModel();

                    if (EmpRepo.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Branch details added successfully";
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
        public ActionResult EditEmpDetails(int id)
        {
            BranchViewModel EmpRepo = new BranchViewModel();



            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Id == id));

        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]
        [Area("Admin")]
        public ActionResult EditEmpDetails(int id, BranchModel obj)
        {
            try
            {
                BranchViewModel EmpRepo = new BranchViewModel();

                EmpRepo.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }
        [Area("Admin")]
        // GET: Employee/DeleteEmp/5    
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                BranchViewModel EmpRepo = new BranchViewModel();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Branch details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }

    }
}