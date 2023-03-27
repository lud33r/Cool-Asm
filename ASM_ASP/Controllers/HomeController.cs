using ASM_ASP.IServices;
using ASM_ASP.Models;
using ASM_ASP.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASM_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _productService = new ProductService();
            _userService = new UserService();
            _roleService = new RoleService();
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_userService.Create(user))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        public bool CheckLogin(string email, string password)
        {
            var user = _userService.GetByEmail(email.Trim());
            if (user != null && user.Password == password && user.Status == 1)
            {
                var role = _roleService.GetById(user.RoleId);
                if (role.Name != "Staff") return true;
            }
            return false;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var isValid = CheckLogin(email, password);
            if (isValid)
            {
                var user = _userService.GetByEmail(email.Trim());
                var userId = user.Id.ToString();
                HttpContext.Session.SetString("userId", userId);
                if (user != null)
                    return RedirectToAction("Index");
                ViewData["ErrorMessage"] = "User not found";
            }
            else
            {
                ViewBag.ErrorMessage = "The user name or password provided is incorrect.";
            }
            return BadRequest();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userId");
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}