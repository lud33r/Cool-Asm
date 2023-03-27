using ASM_ASP.IServices;
using ASM_ASP.Models;
using ASM_ASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASP.Controllers
{
    public class BillController : Controller
    {
        private readonly ILogger<BillController> _logger;
        private readonly IBillService _billServices;
        private readonly IProductService _productServices;
        private readonly IBillDetailService _billDetailServices;
        private readonly ICartDetailService _cartDetailServices;
        public BillController(ILogger<BillController> logger)
        {
            _logger = logger;
            _billServices = new BillService();
            _productServices = new ProductService();
            _billDetailServices = new BillDetailService();
            _cartDetailServices = new CartDetailService();

        }
        public ActionResult CreateBill(Guid userId)
        {
            List<CartDetail> lstCartdetails = _cartDetailServices.GetAll().Where(c => c.UserId == userId).ToList();

            var bill = new Bill()
            {
                Id = Guid.NewGuid(),
                DateofCreation = DateTime.Now,
                UserId = userId,
                Status = 1,
            };

            if (_billServices.Create(bill))
            {
                foreach (var x in lstCartdetails)
                {
                    var billDetail = new BillDetail()
                    {
                        ProductId = x.ProductId,
                        BillId = bill.Id,
                        Quantity = x.Quantity,
                        Price = _productServices.GetAll().FirstOrDefault(c => c.Id == x.ProductId).Price,
                    };
                    _billDetailServices.Create(billDetail);
                    _cartDetailServices.Delete(x.ProductId, x.UserId);
                    var product = _productServices.GetAll().FirstOrDefault(c => c.Id == x.ProductId);
                    product.AvailableQuantity = product.AvailableQuantity - x.Quantity;
                    _productServices.Update(product);
                }

                return RedirectToAction("Show", new { billId = bill.Id });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult DetailsBill(Guid id)
        {
            var obj = _billServices.GetById(id);
            return View(obj);
        }
        public IActionResult ShowBill(Guid id)
        {
            var listBilldetails = _billDetailServices.GetAll();
            ViewBag.listBillDetails = listBilldetails.Where(c => c.BillId == id).ToList();
            ViewBag.listProduct = _productServices.GetAll();
            return View();
        }
    }
}
