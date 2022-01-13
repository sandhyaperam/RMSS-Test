using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using InventoryApplication.Areas.Admin.ViewModel;
using InventoryApplication.Areas.Admin.Models;

namespace InventoryApplication.Areas.Admin.Controllers
{
    public class StateController : Controller
    {

        [Area("Admin")]

        public ActionResult Index()
        {
            StateModel sd = new StateModel();
               StateViewModel fruit = new StateViewModel();
               sd .Countrys = fruit.PopulateFruits();
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public ActionResult Index(StateModel State)
        {
            StateViewModel fruit = new StateViewModel();
            State.Countrys = fruit. PopulateFruits();
            var selectedItem = State.Countrys.Find(p => p.Value == State.Countryid.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
               
            }

            return View(fruit);
        }


    }
}