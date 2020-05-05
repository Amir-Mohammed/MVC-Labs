using System;
using System.Web.Mvc;
using ITI.UI40Smart.MVC.Day02.Models;
using ITI.UI40Smart.MVC.Day02.Models.Entities;

namespace ITI.UI40Smart.MVC.Day02.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            if (!ModelState.IsValid) return View();
            var ctx = new ModelContext();

            ctx.Employees.Add(employee);
            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                ModelState.AddModelError("Email", @"Email is already taken");
                return View();
            }

            return View("profile");
        }
    }
}