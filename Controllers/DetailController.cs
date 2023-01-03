using CourseWorkFactoryAutomatization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            IEnumerable<Technic> technics = workContext.Technics.ToList();
            ViewBag.Technics = new SelectList(technics, "Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult CreateDetail(Detail d)
        {
            workContext.Details.Add(d);
            workContext.SaveChanges();
            return Redirect("/Detail");
        }

        public IActionResult GetDetails()
        {
            using (var context = workContext) 
            {
                return View(context.Details.Include(u => u.Technic).ToList());
            }
        }
        public IActionResult EditDetail(Detail d)
        {
            using (var context = workContext)
            {
                context.Entry(d).State = EntityState.Modified;
                context.SaveChanges();
            }
            return Redirect("/GetDetails");
        }
        [HttpGet]
        public IActionResult EditDetail(int id)
        {
            
            using (var context = workContext)
            {
                IEnumerable<Technic> technics = context.Technics.ToList();
                ViewBag.Technics = new SelectList(technics, "Id", "Title");
                return View(context.Details.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpGet]
        public IActionResult InfoDetails(int id)
        {
            using (var context = workContext)
            {
                return View(context.Details.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        public IActionResult DeleteDetail(int id, Detail detail) {
            detail = workContext.Details.Where(d => d.Id == id).First();
            workContext.Details.Remove(detail);
            workContext.SaveChanges();
            return Redirect("/");
        }
    }
}
