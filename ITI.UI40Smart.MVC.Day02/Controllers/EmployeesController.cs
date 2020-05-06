using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ITI.UI40Smart.MVC.Day02.Models;
using ITI.UI40Smart.MVC.Day02.Models.Entities;

namespace ITI.UI40Smart.MVC.Day02.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        ModelContext context = new ModelContext();

        [HttpGet]

        public ViewResult Index()
        {
            return View(context.Employees.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("EmployeeForm");
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            ViewBag.Action = "Add";
            if (!ModelState.IsValid) return View("EmployeeForm");
            context.Employees.Add(employee);
            try
            {
                context.SaveChanges();
            }
            catch
            {
                ModelState.AddModelError("Email", "Email Address is already taken");
                return View("EmployeeForm");
            }

            return RedirectToAction(nameof(Index));

        }
        [ChildActionOnly]
        public PartialViewResult EmployeePartial(int id)
        {
            Employee employee = context.Employees.Find(id);
            return PartialView("_EmployeePartial", employee);
        }

        public ActionResult Details(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            return View("EmployeeForm", context.Employees.FirstOrDefault(emp => emp.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            ViewBag.Action = "Edit";
            if (!ModelState.IsValid) return View("EmployeeForm", employee);
            context.Employees.Attach(employee);
            context.Entry(employee).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch
            {
                ModelState.AddModelError("Email", "Email Address is already taken");
                return View("EmployeeForm", employee);
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }
    }
}