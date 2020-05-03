using System.Web.Mvc;

namespace ITI.UI40Smart.MVC.Day01.Controllers
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public bool Attendance { get; set; }

    }
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.welcome = "Good afternoon World (from the view)";
            return View();
        }

        [HttpGet]
        public ViewResult Form()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Form(User user)
        {
            if (user?.Name == null || user.Email == null || user.Phone == null) return View();
            ViewBag.name = user.Name;
            ViewBag.attendance = user.Attendance;
            ViewBag.message = ViewBag.attendance ? "It's great that you are coming" : "We are sorry that you can't come";
            return View("Welcome");
        }
    }
}