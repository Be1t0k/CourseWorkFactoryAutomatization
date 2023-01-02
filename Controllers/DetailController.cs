using CourseWorkFactoryAutomatization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CourseWorkFactoryAutomatization.Controllers
{
    public class DetailController : Controller
    {
        private CourseWorkContext workContext;
        public IActionResult Index()
        {
            return View();
        }
        public DetailController(CourseWorkContext courseWorkContext)
        {
            workContext = courseWorkContext;
        }
        [HttpGet]
        public IActionResult CreateDetail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDetail(Detail d)
        {
            workContext.Details.Add(d);
            workContext.SaveChanges();
            return Redirect("/");
        }
    }
}
