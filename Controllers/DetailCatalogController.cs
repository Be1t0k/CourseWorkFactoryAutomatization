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
    public class DetailCatalogController : Controller
    {
        private readonly CourseWorkContext workContext;

        public DetailCatalogController(CourseWorkContext courseWorkContext)
        {
            workContext = courseWorkContext;
        }

        // GET: DetailCatalog
        public IActionResult GetDetailCatalogs()
        {
              return View(workContext.DetailCatalogs.ToList());
        }

        // GET: DetailCatalog/Details/5
        [HttpGet]
        public IActionResult InfoDetailCatalog(int id)
        {

            var detailCatalog =  workContext.DetailCatalogs
                .Include(u => u.Details)
                .ThenInclude(j => j.Technic)
                .FirstOrDefault(m => m.Id == id);

            return View(detailCatalog);
        }

        // GET: DetailCatalog/Create
        [HttpGet]
        public IActionResult CreateDetailCatalog()
        {
            return View();
        }

        // POST: DetailCatalog/Create
        [HttpPost]
        public IActionResult CreateDetailCatalog(DetailCatalog dc)
        {
            workContext.DetailCatalogs.Add(dc);
            workContext.SaveChanges();
            return Redirect("/DetailCatalog/GetDetailCatalogs");
        }

        // POST: DetailCatalog/Edit/5
        public IActionResult EditDetailCatalog(DetailCatalog dc)
        {
            workContext.Entry(dc).State = EntityState.Modified;
            workContext.SaveChanges();
            return Redirect("/DetailCatalog/GetDetailCatalogs");
        }

        [HttpGet]
        public IActionResult EditDetailCatalog(int id)
        {
            return View(workContext.DetailCatalogs.Where(x => x.Id == id).FirstOrDefault());
        }

        // GET: DetailCatalog/Delete/5
        public IActionResult DeleteDetailCatalog(int id, DetailCatalog detailCatalog)
        {
            detailCatalog = workContext.DetailCatalogs.Where(d => d.Id == id).First();
            workContext.DetailCatalogs.Remove(detailCatalog);
            workContext.SaveChanges();
            return Redirect("/DetailCatalog/GetDetailCatalogs");
        }

    }
}