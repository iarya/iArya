using iArya.DataLayer.Context;
using iArya.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace iArya.Web.Areas.UserPanel.Controllers
{


    
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly iAryaDbContext _context;

        public HomeController(iAryaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            int userId = int.Parse(User.FindFirstValue("UserId"));
            var user = _context.Users.Find(userId);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(User user)
        {
            int userId = int.Parse(User.FindFirstValue("UserId"));
            var currentUser = _context.Users.Find(userId);
            currentUser.UserName = user.UserName;
            currentUser.Email = user.Email;
            currentUser.UpdateDate = DateTime.Now;
            _context.SaveChanges();
            ViewBag.IsEdit = true;
            return View(user);
        }





        [Route("Users")]
        public IActionResult UsersList()
        {
            var res = _context.Users.OrderByDescending(x => x.CreateDate).ToList();






            return View(res);
        }

    }
}
