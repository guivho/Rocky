using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applicationTypeList = 
                (IEnumerable<ApplicationType>)_db.ApplicationType;
            return View(applicationTypeList);
        }

        // get - create
        public IActionResult Create()
        {
            return View();
        }

        // post - create
        [HttpPost]
        public IActionResult Create(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Add(applicationType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }

        // edit - get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var applicationType = _db.ApplicationType.Find(id);
            if (applicationType == null)
            {
                return NotFound();
            }
            return View(applicationType);
        }

        // edit - put
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(applicationType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }

        // edit - get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var applicationType = _db.ApplicationType.Find(id);
            if (applicationType == null)
            {
                return NotFound();
            }
            return View(applicationType);
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
            var applicationType = _db.ApplicationType.Find(id);
            if (applicationType == null)
            {
                return NotFound();
            }
            _db.ApplicationType.Remove(applicationType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
