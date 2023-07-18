using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _ProductRepo;
        public ProductController(IProductRepository db)
        {
            _ProductRepo = db;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _ProductRepo.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            /*if (obj.Title == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot match the name.");
            }*/

            if (ModelState.IsValid)
            {
                _ProductRepo.Add(obj);
                _ProductRepo.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductfromDb = _ProductRepo.Get(u => u.Id == id);

            if (ProductfromDb == null)
            {
                return NotFound();
            }
            return View(ProductfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _ProductRepo.Update(obj);
                _ProductRepo.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductfromDb = _ProductRepo.Get(u => u.Id == id);

            if (ProductfromDb == null)
            {
                return NotFound();
            }
            return View(ProductfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _ProductRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _ProductRepo.Remove(obj);
            _ProductRepo.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
