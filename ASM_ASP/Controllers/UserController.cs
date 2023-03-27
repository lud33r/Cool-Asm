using Microsoft.AspNetCore.Mvc;

namespace ASM_ASP.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
