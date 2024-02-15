using Bulky.DataAccess.Data;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
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
                _db.Categories.Add(category);
                _db.SaveChanges();
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
            Category? ct1 = _db.Categories.Find(categoryId);
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
                _db.Categories.Update(category);
                _db.SaveChanges();
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
            Category? ct1 = _db.Categories.Find(categoryId);
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
            Category? _cat = _db.Categories.Find(categoryId);
            if (_cat != null)
            {
                TempData["success"] = "Category Deleted successfully!";
                _db.Categories.Remove(_cat);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Category");
        }
    }
}
