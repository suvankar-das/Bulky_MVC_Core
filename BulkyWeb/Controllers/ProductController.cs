using Bulky.DataAccess.Repository;
using Bulky.Models.Models;
using Bulky.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Controllers
{
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        
        public ProductController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> selectLists = _unitOfWork.Category.GetAll().ToList().Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Product = new Product(),
                CategoryList = selectLists,
            };
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Product added successfully!";
                _unitOfWork.Product.AddItem(vm.Product);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int productId)
        {
            if (productId == 0 || productId == null)
            {
                return NotFound();
            }
            // fetch category from db
            // find only works for finding primary key field.
            Product? ct1 = _unitOfWork.Product.GetItem(c => c.Id == productId);
            //Category? ct2 = _db.Categories.FirstOrDefault(c => c.Id == categoryId);

            IEnumerable<SelectListItem> selectLists = _unitOfWork.Category.GetAll().ToList().Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ProductViewModel model = new ProductViewModel()
            {
                Product = ct1,
                CategoryList = selectLists
            };

            if (ct1 == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Product Edited successfully!";
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int productId)
        {
            if (productId == 0 || productId == null)
            {
                return NotFound();
            }
            // fetch category from db
            // find only works for finding primary key field.
            Product? ct1 = _unitOfWork.Product.GetItem(c => c.Id == productId);
            //Category? ct2 = _db.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (ct1 == null)
            {
                return NotFound();
            }
            return View(ct1);
        }


        // This is because Delete(int categoryId) is already declared so ,So signature will be same here
        // Thats why I am specifying ActionName as Delete as an Endpoint

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int productId)
        {
            Product? _cat = _unitOfWork.Product.GetItem(c => c.Id == productId);
            if (_cat != null)
            {
                TempData["success"] = "Product Deleted successfully!";
                _unitOfWork.Product.RemoveItem(_cat);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
