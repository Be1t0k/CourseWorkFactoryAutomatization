using CourseWorkFactoryAutomatization.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseWorkFactoryAutomatization.Controllers
{
    public class TechnicController : Controller
    {
        private CourseWorkContext workContext;
        public IActionResult Index()
        {
            return View();
        }

        public TechnicController(CourseWorkContext courseWorkContext)
        {
            workContext = courseWorkContext;
        }
        [HttpGet]
        public IActionResult CreateTechnic()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTechnic(Technic t)
        {
            workContext.Technics.Add(t);
            workContext.SaveChanges();
            return Redirect("/");
        }
    }
}
