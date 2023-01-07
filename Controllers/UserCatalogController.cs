using CourseWorkFactoryAutomatization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkFactoryAutomatization.Controllers
{
    public class UserCatalogController : Controller
    {
        private readonly CourseWorkContext workContext;

        public UserCatalogController(CourseWorkContext courseWorkContext)
        {
            workContext = courseWorkContext;
        }

        // GET: DetailCatalog
        public IActionResult GetUserCatalogs()
        {
            return View(workContext.UserCatalogs.ToList());
        }

        // GET: DetailCatalog/Details/5
        [HttpGet]
        public IActionResult InfoUserCatalog(int id)
        {

            var userCatalog = workContext.UserCatalogs
                .Include(u => u.Users)
                .FirstOrDefault(m => m.Id == id);

            return View(userCatalog);
        }

        // GET: DetailCatalog/Create
        [HttpGet]
        public IActionResult CreateUserCatalog()
        {
            return View();
        }

        // POST: DetailCatalog/Create
        [HttpPost]
        public IActionResult CreateUserCatalog(UserCatalog userCatalog)
        {
            workContext.UserCatalogs.Add(userCatalog);
            workContext.SaveChanges();
            return Redirect("/UserCatalog/GetUserCatalogs");
        }

        // POST: DetailCatalog/Edit/5
        public IActionResult EditUserCatalog(UserCatalog userCatalog)
        {
            workContext.Entry(userCatalog).State = EntityState.Modified;
            workContext.SaveChanges();
            return Redirect("/UserCatalog/GetUserCatalogs");
        }

        [HttpGet]
        public IActionResult EditUserCatalog(int id)
        {
            return View(workContext.UserCatalogs.Where(x => x.Id == id).FirstOrDefault());
        }

        // GET: DetailCatalog/Delete/5
        public IActionResult DeleteUserCatalog(int id, UserCatalog userCatalog)
        {
            userCatalog = workContext.UserCatalogs.Where(d => d.Id == id).First();
            workContext.UserCatalogs.Remove(userCatalog);
            workContext.SaveChanges();
            return Redirect("/UserCatalog/GetUserCatalogs");
        }

    }
}
