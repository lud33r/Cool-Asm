using ASM_ASP.IServices;
using ASM_ASP.Models;
using ASM_ASP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace ASM_ASP.Controllers
{
	public class CartController : Controller
	{
        private readonly ILogger<CartController> _logger;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly ICartDetailService _cartDetailService;
        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            _cartService = new CartService();
            _productService = new ProductService();
            _cartDetailService = new CartDetailService();
        }
        public IActionResult Index()
		{
			return View();
		}
        public IActionResult ShowCart(Guid idUser)
        {
            //var userId = HttpContext.Session.GetString("userId");
            //ViewData["userId"] = userId;
            //if (!string.IsNullOrEmpty(userId))
            //{
            //    ViewBag.listCartDetails = _cartDetailService.GetAll().Where(c => c.UserId == Guid.Parse(userId)).ToList();
            //    ViewBag.listProduct = _productService.GetAll();
            //    return View();
            //}
            //return RedirectToAction("Login", "Home");
            idUser = Guid.Parse("8871ad42-6960-473d-aa75-aabc6edf5014");
            //if (idUser == Guid.Empty)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            var listCartDetails =  _cartDetailService.GetAll();
            ViewBag.listCartDetails = listCartDetails.Where(c => c.UserId == idUser && c.Status == 0).ToList();
            ViewBag.listProduct =  _productService.GetAll();

            return View();
        }
        public IActionResult Create(/*Guid productId*/ Guid idProduct, Guid idUser) 
        {
            //var userId = HttpContext.Session.GetString("userId");
            //Guid id = Guid.Parse(userId);
            //if (!string.IsNullOrEmpty(userId))
            //{
            //    List<CartDetail> cartDetails = _cartDetailService.GetAll().Where(c => c.UserId == id).ToList();
            //    CartDetail obj = new()
            //    {
            //        UserId = id,
            //        ProductId = productId,
            //        Quantity = 1
            //    };
            //    if (cartDetails.Any(c => c.UserId == id && c.ProductId == productId))
            //    {
            //        obj.Quantity = cartDetails.FirstOrDefault(c => c.UserId == id && c.ProductId == productId).Quantity + 1;
            //        return _cartDetailService.Update(obj.ProductId, obj.UserId, obj) ? RedirectToAction("Show") : BadRequest();
            //    }
            //    else
            //    {
            //        return _cartDetailService.Create(obj) ? RedirectToAction("Show") : BadRequest();
            //    }
            //}
            //return BadRequest();

            List<CartDetail> cartDetails =  _cartDetailService.GetAll();

            CartDetail obj = new()
            {
                UserId = idUser,
                ProductId = idProduct,
                Quantity = 1
            };

            // Check sản phẩm đã có trong giỏ hàng hay chưa
            // Nếu có => Update +1 cho Amount
            // Nếu không => Create
            if (cartDetails.Any(c => c.UserId == idUser && c.ProductId == idProduct))
            {
                // Update
                if (cartDetails.FirstOrDefault(c => c.UserId == idUser && c.ProductId == idProduct).Status == 0)
                {
                    obj.Quantity = cartDetails.FirstOrDefault(c => c.UserId == idUser && c.ProductId == idProduct).Quantity + 1;
                }

                var resultUpdate = _cartDetailService.Update(obj.ProductId, obj.UserId, obj);

                if (resultUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result = _cartDetailService.Create(obj);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(Guid productId, Guid userId)
        {
            ViewBag.cartDetails = _cartDetailService.GetById(productId, userId);

            return View();
        }

        public IActionResult Delete(Guid productId)
        {
            Guid id = Guid.Parse(HttpContext.Session.GetString("userId"));
            return _cartDetailService.Delete(productId, id) ? RedirectToAction("Show") : BadRequest();
        }

        public IActionResult Edit(CartDetail obj)
        {
            obj.UserId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            var result = _cartDetailService.Update(obj.ProductId, obj.UserId, obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
