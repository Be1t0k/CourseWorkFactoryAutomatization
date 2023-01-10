using CourseWorkFactoryAutomatization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkFactoryAutomatization.Controllers
{
    public class AccountController : Controller
    {
        private readonly CourseWorkContext workContext;

        public AccountController(CourseWorkContext courseWorkContext)
        {
            workContext = courseWorkContext;
        }

        public IActionResult Login([Bind("Email,Password")] User user)
        {
            if (workContext.Accountants.Any(a => a.Password == user.Password && a.Email == user.Email))
            {
                long id = workContext.Accountants.Where(a => a.Password == user.Password && a.Email == user.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());

                return RedirectToAction("GetDetails", "Detail", new { id = id });
            }
            else if (workContext.SuperVisors.Any(a => a.Password == user.Password && a.Email == user.Email))
            {
                long id = workContext.SuperVisors.Where(a => a.Password == user.Password && a.Email == user.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());

                return RedirectToAction("GetTechnics", "Technic", new { id = id });
            }
            else if (workContext.Admins.Any(a => a.Password == user.Password && a.Email == user.Email))
            {
                long id = workContext.Admins.Where(a => a.Password == user.Password && a.Email == user.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());

                return RedirectToAction("GetUsers", "Account", new { id = id });
            }
            return View();
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("userId");
            return RedirectToAction("Index", "Home"); //добавить контроллер и метод для главной страницы
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            var Disc = new List<String>() { "Accountant", "SuperVisor", "Admin" };
            ViewBag.Discriminators = new SelectList(Disc);
            IEnumerable<User> users = workContext.Users.ToList();
            ViewBag.Users = new SelectList(users, "Id", "Name", "Surname");
            return View();
        }
        //Create-Post
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            workContext.Users.Add(user);
            workContext.SaveChanges();
            return Redirect("/Account/GetUsers");
        }

        public IActionResult GetUsers()
        {
            return View(workContext.Users.ToList());
        }

        public IActionResult EditUser(User d)
        {

            workContext.Entry(d).State = EntityState.Modified;
            workContext.SaveChanges();
            return Redirect("/Account/GetUsers");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            return View(workContext.Users.Where(x => x.Id == id).FirstOrDefault());

        }
        [HttpGet]
        public IActionResult InfoUser(int id)
        {
            return View(workContext.Users.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult DeleteUser(int id, User user)
        {
            user = workContext.Users.Where(d => d.Id == id).First();
            workContext.Users.Remove(user);
            workContext.SaveChanges();
            return Redirect("/Account/GetUsers");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}