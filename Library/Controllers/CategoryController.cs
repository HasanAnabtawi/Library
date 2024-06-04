using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()


        {
            var data = _db.Categories.ToList();
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CategoryAdd()


        {

            return View();

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CategoryAdd(CategoryModel obj)


        {
            _db.Categories.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CategoryEdit(int id)


        {

            var data=_db.Categories.FirstOrDefault(c => c.Id == id);
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel obj)


        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult CategoryDelete(int? id)


        {
            var data = _db.Categories.FirstOrDefault(c => c.Id == id);
            return View(data);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult CategoryDelete(CategoryModel obj)


        {
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

