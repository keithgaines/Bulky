using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Bulky.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // This action displays a list of products on the customer's home page.
        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");
            return View(productList);
        }

        // This action displays details about a specific product based on its ID.
        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                // Retrieve the product details and related information from the database.
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }

        // This action handles adding products to the shopping cart.
        [HttpPost]
        [Authorize] // Requires the user to be authenticated.
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            // Check if the product is already in the user's shopping cart.
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
            u.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null) // if shopping cart already exists
            {
                // Increase the quantity of an existing product in the cart.
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                // Add a new product to the user's shopping cart.
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
                // Update the shopping cart count in the session.
                HttpContext.Session.SetInt32(SD.SessionCart,
                _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }
            TempData["success"] = "Cart updated successfully";

            // Redirect the user back to the product list.
            // nameof references all the action methods in the controller
            // meaning that instead of RedirectToAction("Index") you use nameof(ActionMethod) rather than the string name of the view
            return RedirectToAction(nameof(Index));
        }

        // This action displays the privacy policy page.
        public IActionResult Privacy()
        {
            return View();
        }

        // This action handles displaying error information.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
