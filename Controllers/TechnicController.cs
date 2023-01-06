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
            return Redirect("/Technic/GetTechnics");
        }
        //GetTech-Get
        public IActionResult GetTechnics()
        {

                return View(workContext.Technics.ToList());
            
        }
        //Info-Get
        [HttpGet]
        public IActionResult InfoTechnics(int id)
        {
            var technic = workContext.Technics.Include(u => u.Details)
            .FirstOrDefault(m => m.Id == id);
            return View(technic);
                //return View(workContext.Technics.Where(x => x.Id == id).FirstOrDefault());
            
        }
        //Edit-Post
        public IActionResult EditTechnic(Technic t)
        {

                workContext.Entry(t).State = EntityState.Modified;
                workContext.SaveChanges();
            
            return Redirect("/Technic/GetTechnics");
        }
        //Edit-Get
        [HttpGet]
        public IActionResult EditTechnic(int id)
        {

                return View(workContext.Technics.Where(x => x.Id == id).FirstOrDefault());
            
        }

        //Delete-Post
        public IActionResult DeleteTechnic(int id, Technic technic)
        {
            technic = workContext.Technics.Where(d => d.Id == id).First();
            workContext.Technics.Remove(technic);
            workContext.SaveChanges();
            return Redirect("/Technic/GetTechnics");
        }

        [HttpGet]
        public IActionResult TechExpenses()
        {
            //select t."Title", count(d."Id") from "Technics" as t left join "Details" as d on "TechnicId" = t."Id" group by t."Title";
            var technic = workContext.Technics.Where(u =>u.Details == null).FirstOrDefault();
            return View(technic);
        }
    }
}
