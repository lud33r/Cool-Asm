using ASM_ASP.IServices;
using ASM_ASP.Models;
using ASM_ASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASP.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = new ProductService();
        }

        public ActionResult ShowAllProduct()
        {
            List<Product> products = _productService.GetAll();
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product p, IFormFile imageFile)
        {
            // Trong trường hợp chúng ta thực hiện với thuộc tính Description
            // Thuộc tính này đang là string => Không thể thao tác trực tiếp
            // với các file => Truyền thêm 1 tham số vào Action này
            // Truyền thêm 1 tham số imageFile kiểu IFormFile
            // Bước 1: Kiểm tra đường dãn tới ảnh được lấy từ form
            if (imageFile != null && imageFile.Length > 0) // Không null không rỗng
            {
                // Thực hiện trỏ tới thư mục root để lát thực hiện việc copy
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "images", imageFile.FileName); // Bước 2
                // Kết quả: aaa/wwwroot/images/xxx.jpg, Path.Combine = tổng hợp đường dẫn
                var stream = new FileStream(path, FileMode.Create);
                // Vì chúng ta thực hiện việc copy => Tạo mới => Create
                imageFile.CopyTo(stream); // Copy ảnh chọn ở form vào wwwroot/images
                // Gán lại giá trị cho thuộc tính Description => Bước 3
                p.Description = imageFile.FileName; // Bước 4
            }
            if (_productService.Create(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        public IActionResult DetailsProduct(Guid id)
        {
            var product = _productService.GetById(id);
            return View(product);

        }

        public IActionResult DeleteProduct(Guid id)
        {
            if (_productService.Delete(id))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }

        [HttpGet]
        public IActionResult EditProduct(Guid id)
        {
                      
			var product = _productService.GetById(id);
			var products = SessionService.GetObjFromSession(HttpContext.Session, "History");
			var existingProduct = products.FirstOrDefault(p => p.Id == id);
			if (products.Count == 0)
			{
				products.Add(product);
				SessionService.SetObjToSession(HttpContext.Session, "History", products);
			}
			else
			{
				if (SessionService.CheckObjInList(id, products))
				{
					if (existingProduct != null)
					{
						return View(product);
					}
					else
					{
						products.Remove(existingProduct);
					}
				}
				else
				{
					products.Add(product);
					SessionService.SetObjToSession(HttpContext.Session, "History", products);
				}
			}
			return View(product);
		}
        public IActionResult EditProduct(Product p)
        {

            if (_productService.Update(p))
            {
                return RedirectToAction("ShowAllProduct");
            }
            else return BadRequest();
        }
        

        [HttpPost]
		public IActionResult CallBack(Guid id, string action)
		{
			if (action == "CallBack")
			{
				var obj = SessionService.GetObjFromSession(HttpContext.Session, "History").FirstOrDefault(p => p.Id == id);
				if (_productService.Update(obj))
				{
					return RedirectToAction("ShowAllProduct");
				}
				else return BadRequest();
			}
			else
			{
				var product = _productService.GetById(id);
				return RedirectToAction("UpdateProduct", product);
			}
		}
		public IActionResult HistoryEdit()
		{
			var products = SessionService.GetObjFromSession(HttpContext.Session, "History");
			return View(products);
		}
        public IActionResult AddToCart(Guid id)
        {
            //B1: Dua vao id lay ra san pham
            var product = _productService.GetById(id);
            //B2: Lay danh sach san pham ra tu session
            var products = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            if (products.Count == 0)
            {
                products.Add(product);// them truc tiep sp vao neu list trong
                SessionService.SetObjToSession(HttpContext.Session, "Cart", products);
            }
            else
            {
                if (SessionService.CheckObjInList(id, products))
                {//kiem tra xem list lay ra co chua sp hay chua
                    return Content("Binh thuong chung ta se them so luong nhung vi luoi nen che ma chi dua ra thong bao nay");
                }
                else
                {
                    products.Add(product);// them truc tiep sp vao neu list trong chua chua sp 
                    SessionService.SetObjToSession(HttpContext.Session, "Cart", products);
                }
            }
            //B3: Kiem tra va them san pham vao gio hang
            return RedirectToAction("ShowCart");
        }
		public IActionResult ShowCart()
		{
			//Lay du lieu tu session de truyen vao view
			var products = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
			return View(products);
		}
	}
}
