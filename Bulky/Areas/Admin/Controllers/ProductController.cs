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

        public IActionResult Create()
        {
            var categories = _unitOfWork.Category.GetAll().ToList();
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Product.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Product created successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    _unitOfWork.Product.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Product updated successfully.";
                    return RedirectToAction("Index");
                }
            }

            var categories = _unitOfWork.Category.GetAll().ToList();
            ViewData["Categories"] = categories;

            if (obj.Id == 0)
            {
                return View(obj);
            }
            else
            {
                var existingProduct = _unitOfWork.Product.Get(obj.Id);
                if (existingProduct == null)
                {
                    return NotFound();
                }
                return View(existingProduct);
            }
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _unitOfWork.Product.Get(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            var categories = _unitOfWork.Category.GetAll().ToList();
            ViewData["Categories"] = categories;

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }

            var categories = _unitOfWork.Category.GetAll().ToList();
            ViewData["Categories"] = categories;

            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
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
            if (id == null || id == 0)
            {
                return NotFound();
            }

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
