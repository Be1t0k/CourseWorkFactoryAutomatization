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
            return Redirect("/User/GetUsers");
        }

        public IActionResult GetUsers()
        {
            return View(workContext.Users.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}