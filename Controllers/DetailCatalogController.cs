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
        public IActionResult GetDetailCatalog()
        {
              return View(workContext.DetailCatalogs.ToList());
        }

        // GET: DetailCatalog/Details/5
        [HttpGet]
        public IActionResult InfoDetailCatalog(int id)
        {

            var detailCatalog =  workContext.DetailCatalogs.Include(u => u.Details).ThenInclude(j => j.Technic)
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
        

        // GET: DetailCatalog/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || workContext.DetailCatalogs == null)
            {
                return NotFound();
            }

            var detailCatalog = await workContext.DetailCatalogs.FindAsync(id);
            if (detailCatalog == null)
            {
                return NotFound();
            }
            return View(detailCatalog);
        }

        // POST: DetailCatalog/Edit/5
        public IActionResult EditDetailCatalog(DetailCatalog dc)
        {
            workContext.Entry(dc).State = EntityState.Modified;
            workContext.SaveChanges();
            return Redirect("/Technic/GetTechnics");
        }
                

        // GET: DetailCatalog/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || workContext.DetailCatalogs == null)
            {
                return NotFound();
            }

            var detailCatalog = await workContext.DetailCatalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailCatalog == null)
            {
                return NotFound();
            }

            return View(detailCatalog);
        }

        // POST: DetailCatalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (workContext.DetailCatalogs == null)
            {
                return Problem("Entity set 'CourseWorkContext.DetailCatalogs'  is null.");
            }
            var detailCatalog = await workContext.DetailCatalogs.FindAsync(id);
            if (detailCatalog != null)
            {
                workContext.DetailCatalogs.Remove(detailCatalog);
            }
            
            await workContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailCatalogExists(long id)
        {
          return workContext.DetailCatalogs.Any(e => e.Id == id);
        }
    }
}
