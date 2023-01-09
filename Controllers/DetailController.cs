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
        public IActionResult CreateDetail(Detail d)
        {
            workContext.Details.Add(d);
            workContext.SaveChanges();
            return Redirect("/Detail/GetDetails");
        }

        public IActionResult GetDetails()
        {
                return View(workContext.Details
                    .Include(j => j.Technic)
                    .Include(u => u.DetailCatalog)
                    .ToList());
        }
        public IActionResult EditDetail(Detail d)
        {

            workContext.Entry(d).State = EntityState.Modified;
            workContext.SaveChanges();
            return Redirect("/Detail/GetDetails");
        }
        [HttpGet]
        public IActionResult EditDetail(int id)
        {
            IEnumerable<Technic> technics = workContext.Technics.ToList();
            ViewBag.Technics = new SelectList(technics, "Id", "Title");
            IEnumerable<DetailCatalog> detailCatalogs = workContext.DetailCatalogs.ToList();
            ViewBag.DetailCatalogs = new SelectList(detailCatalogs, "Id", "DateCreate");
            return View(workContext.Details.Where(x => x.Id == id).FirstOrDefault());
           
        }
        [HttpGet]
        public IActionResult InfoDetails(int id)
        {
            IEnumerable<Technic> technics = workContext.Technics.ToList();
            ViewBag.Technics = new SelectList(technics, "Id", "Title");
            IEnumerable<DetailCatalog> detailCatalogs = workContext.DetailCatalogs.ToList();
            ViewBag.DetailCatalogs = new SelectList(detailCatalogs, "Id", "DateCreate");
            return View(workContext.Details.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult DeleteDetail(int id, Detail detail) 
        {
            detail = workContext.Details.Where(d => d.Id == id).First();
            workContext.Details.Remove(detail);
            workContext.SaveChanges();
            return Redirect("/Detail/GetDetails");
        }


        [HttpGet]
        public IActionResult InfoExpenses()
        {
            ViewBag.Groupps = workContext.Details.GroupBy(p => p.Title)
                  .Select(g => new { Title = g.Key, Countt = g.Count() }).ToList();
            return View();
        }
    }
}