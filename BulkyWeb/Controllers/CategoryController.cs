using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (Utils.Utils.CheckForSpecialCharacter(category.Name))
            {
                // Name means on which property You want to show this message
                ModelState.AddModelError("Name", "Cannot contain special character");
            }
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category added successfully!";
                _unitOfWork.Category.AddItem(category);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int categoryId)
        {
            if (categoryId == 0 || categoryId == null)
            {
                return NotFound();
            }
            // fetch category from db
            // find only works for finding primary key field.
            Category? ct1 = _unitOfWork.Category.GetItem(c=>c.Id==categoryId);
            //Category? ct2 = _db.Categories.FirstOrDefault(c => c.Id == categoryId);
            
            if (ct1 == null)
            {
                return NotFound();
            }
            return View(ct1);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category Edited successfully!";
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int categoryId)
        {
            if (categoryId == 0 || categoryId == null)
            {
                return NotFound();
            }
            // fetch category from db
            // find only works for finding primary key field.
            Category? ct1 = _unitOfWork.Category.GetItem(c=>c.Id==categoryId);
            //Category? ct2 = _db.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (ct1 == null)
            {
                return NotFound();
            }
            return View(ct1);
        }


        // This is because Delete(int categoryId) is already declared so ,So signature will be same here
        // Thats why I am specifying ActionName as Delete as an Endpoint

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteCategory(int categoryId)
        {
            Category? _cat = _unitOfWork.Category.GetItem(c => c.Id == categoryId);
            if (_cat != null)
            {
                TempData["success"] = "Category Deleted successfully!";
                _unitOfWork.Category.RemoveItem(_cat);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index", "Category");
        }
    }
}
