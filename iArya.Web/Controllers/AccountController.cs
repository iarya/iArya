using iArya.Application.ViewModels;
using iArya.DataLayer.Interfaces;
using iArya.Domain.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace iArya.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }


            if (_userRepository.ExiestEmail(register.Email.Trim().ToLower()))
            {
                ModelState.AddModelError("Email", "ایمیل تکراری وارد شده است");
                return View(register);
            }


            User user = new User()
            {
                CreateDate = DateTime.Now,
                Email = register.Email.Trim().ToLower(),
                IsDelete = false,
                Password = register.Password,
                RoleId = 1,
                UserName = register.UserName,
            };
            _userRepository.Add(user);
            _userRepository.Save();

            ViewBag.SuccessRegister = true;

            return View(register);
        }



        [Route("Login")]
        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginVM login)
        {
            if(!ModelState.IsValid)
                return View(login);

            var user = _userRepository.GetUserByUsername(login.UserName);
            if (user == null)
            {
                ModelState.AddModelError("Username", "اطلاعات را بررسی کنید");
                return View(login);
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("UserId",user.UserId.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe,
            };
            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }
    }

    }

