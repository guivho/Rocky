using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Category;
            return View(categoryList);
        }

        // get - create
        public IActionResult Create()
        {
            return View();
        }

        // create - post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // edit - get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Category.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // edit - put
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
         {
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // edit - get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // edit - put
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Category.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
