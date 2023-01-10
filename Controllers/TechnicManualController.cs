using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseWorkFactoryAutomatization.Models;

namespace CourseWorkFactoryAutomatization.Controllers
{
    public class TechnicManualController : Controller
    {
        private readonly CourseWorkContext workContext;

        public TechnicManualController(CourseWorkContext courseWorkContext)
        {
            workContext = courseWorkContext;
        }

        // GET: DetailCatalog
        public IActionResult GetTechnicManuals()
        {
            return View(workContext.TechnicManuals.ToList());
        }

        // GET: DetailCatalog/Details/5
        [HttpGet]
        public IActionResult InfoTechnicManual(int id)
        {

            var technicManual = workContext.TechnicManuals
                .Include(u => u.Technics)
                .FirstOrDefault(m => m.Id == id);

            return View(technicManual);
        }

        // GET: DetailCatalog/Create
        [HttpGet]
        public IActionResult CreateTechnicManual()
        {
            return View();
        }

        // POST: DetailCatalog/Create
        [HttpPost]
        public IActionResult CreateTechnicManual(TechnicManual tm)
        {
            workContext.TechnicManuals.Add(tm);
            workContext.SaveChanges();
            return Redirect("/TechnicManual/GetTechnicManuals");
        }

        // POST: DetailCatalog/Edit/5
        public IActionResult EditTechnicManual(TechnicManual tm)
        {
            workContext.Entry(tm).State = EntityState.Modified;
            workContext.SaveChanges();
            return Redirect("/TechnicManual/GetTechnicManuals");
        }

        [HttpGet]
        public IActionResult EditTechnicManual(int id)
        {
            return View(workContext.TechnicManuals.Where(x => x.Id == id).FirstOrDefault());
        }

        // GET: DetailCatalog/Delete/5
        public IActionResult DeleteTechnicManual(int id, TechnicManual technicManual)
        {
            technicManual = workContext.TechnicManuals.Where(d => d.Id == id).First();
            workContext.TechnicManuals.Remove(technicManual);
            workContext.SaveChanges();
            return Redirect("/TechnicManual/GetTechnicManuals");
        }
    }
}