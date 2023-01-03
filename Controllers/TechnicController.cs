using CourseWorkFactoryAutomatization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        //Create-Get
        [HttpGet]
        public IActionResult CreateTechnic()
        {
            return View();
        }
        //Create-Post
        [HttpPost]
        public IActionResult CreateTechnic(Technic t)
        {
            workContext.Technics.Add(t);
            workContext.SaveChanges();
            return Redirect("/");
        }
        //GetTech-Get
        public IActionResult GetTechnics()
        {
            using (var context = workContext)
            {
                return View(context.Technics.ToList());
            }
        }
        //Info-Get
        [HttpGet]
        public IActionResult InfoTechnics(int id)
        {

            using (var context = workContext)
            {
                return View(context.Technics.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        //Edit-Post
        public IActionResult EditTechnic(Technic t)
        {
            using (var context = workContext)
            {
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
            }
            return Redirect("/GetTechnics");
        }
        //Edit-Get
        [HttpGet]
        public IActionResult EditTechnic(int id)
        {
            using (var context = workContext)
            {
                return View(context.Technics.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        //Delete-Post
        public IActionResult DeleteTechnic(int id, Technic technic)
        {
            technic = workContext.Technics.Where(d => d.Id == id).First();
            workContext.Technics.Remove(technic);
            workContext.SaveChanges();
            return Redirect("/");
        }
    }
}
