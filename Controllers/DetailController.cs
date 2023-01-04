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
            IEnumerable<DetailCatalog> detailCatalogs = workContext.DetailCatalogs.ToList();
            ViewBag.DetailCatalogs = new SelectList(detailCatalogs, "Id", "DateCreate");
            return View();
        }
        [HttpPost]
        public IActionResult CreateDetail(Detail d, DetailCatalog dc)
        {
            workContext.Details.Add(d);
            workContext.DetailCatalogs.Add(dc);
            workContext.SaveChanges();
            return Redirect("/Detail/GetDetails");
        }

        public IActionResult GetDetails()
        {
            using (var context = workContext) 
            {
                return View(context.Details.Include(j => j.Technic)
                       .Include(u => u.DetailCatalog).ToList());
            }
        }
        public IActionResult EditDetail(Detail d)
        {
            using (var context = workContext)
            {
                context.Entry(d).State = EntityState.Modified;
                context.SaveChanges();
            }
            return Redirect("/Detail/GetDetails");
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
            return Redirect("/Detail/GetDetails");
        }
    }
}
