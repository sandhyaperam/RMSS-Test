using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApplication.Models;
using InventoryApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace InventoryApplication.Controllers
{
    public class AdminController : Controller
    {
        private static IConfiguration _configuration;
       
        AdminLoginViewModel dbop = new AdminLoginViewModel();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLogin ad)

        {
            int res = dbop.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Admin Section";
                //  return RedirectToRoute(new { action = "Index", controller = "AdminDashBoard", area = "Admin" });

                return RedirectToAction("DashBoard", "AdminDashBoard", new { area = "Admin" });
            }
            else
            {
                TempData["msg"] = "Userid or Password is wrong.!";
            }
            return View();

           
        }
    }
}