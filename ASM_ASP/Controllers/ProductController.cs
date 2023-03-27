using ASM_ASP.IServices;
using ASM_ASP.Models;
using ASM_ASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASP.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        public ActionResult ShowAllProduct()
        {
            List<Product> products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product p)
        {

            if (_productService.CreateProduct(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        public IActionResult DetailsProduct(Guid id)
        {
            var product = _productService.GetProductById(id);
            return View(product);

        }

        public IActionResult DeleteProduct(Guid id)
        {
            if (_productService.DeleteProduct(id))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        [HttpGet]
        public IActionResult EditProduct(Guid id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }
        public IActionResult EditProduct(Product p)
        {

            if (_productService.UpdateProduct(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
