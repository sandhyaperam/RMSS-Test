using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApplication.Areas.Admin.Controllers
{
    public class AdminDashBoardController : Controller
    {
        [Area("Admin")]
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}