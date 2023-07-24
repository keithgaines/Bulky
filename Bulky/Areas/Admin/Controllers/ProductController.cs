using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            var product = id == 0 ? new Product() : _unitOfWork.Product.Get(id);

            var categories = _unitOfWork.Category.GetAll().ToList();
            ViewData["Categories"] = categories;

            return View(product);
        }

        [HttpPost]
        public IActionResult Upsert(Product obj)
        {
            if (obj.Id == 0)
            {
                _unitOfWork.Product.Add(obj);
                TempData["success"] = "Product created successfully.";
            }
            else
            {
                _unitOfWork.Product.Update(obj);
                TempData["success"] = "Product updated successfully.";
            }

            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            _unitOfWork.Product.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Product obj)
        {
            _unitOfWork.Product.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product updated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var productFromDb = _unitOfWork.Product.Get(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var obj = _unitOfWork.Product.Get(id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
