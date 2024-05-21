using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using LibrarySystem.Data;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.Controllers
{
    [Authorize(Roles= "Admin,HR")]
    public class BookController : Controller

    {


        private ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        public BookController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
       
     


    public IActionResult Index()


        {
            IEnumerable<BookModel> data = _db.Books
                .Include(u => u.Category)
                .ToList();


           





            return View(data);
        }


        [HttpGet]
        public IActionResult BookAdd()
        {

            List<string> status = new List<string>()
            {

                "Available",
                "Not Available"
            };

            

            ViewBag.Status = status;

            IEnumerable<SelectListItem> CategoryList = _db.Categories.Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.Id.ToString()
                
            });

            ViewBag.CategoryList = CategoryList;

            return View();
        }

        [HttpPost]
        public IActionResult BookAdd(BookModel obj, IFormFile? file)
        {

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var BookPath = Path.Combine(wwwRootPath, @"Images\Books");

                using (var filestream = new FileStream(Path.Combine(BookPath, fileName), FileMode.Create))
                {
                    file.CopyTo(filestream);

                };
                obj.ImageUrl = @"\Images\Books\" + fileName;
            }

            _db.Books.Add(obj);
            _db.SaveChanges();


            return RedirectToAction("Index");
        }

   



    [HttpGet]
    public IActionResult BookEdit(int id)
    {

            List<string> status = new List<string>()
            {

                "Available",
                "Not Available"
            };

            ViewBag.Status = status;

            var data=_db.Books.FirstOrDefault(u=>u.Id==id);

            IEnumerable<SelectListItem> CategoryList = _db.Categories.Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.Id.ToString()

            });

            
            ViewBag.CategoryList = CategoryList;



            return View(data);
    }


        [HttpPost]
        
        public IActionResult BookEdit(BookModel obj,IFormFile? file)

        {

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(file != null)
            {
                string fileName=Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
                var BookPath=Path.Combine(wwwRootPath, @"Images\Books");
                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {
                    //deleting of old image
                    var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var filestream = new FileStream(Path.Combine(BookPath, fileName),FileMode.Create))
                {
                    file.CopyTo(filestream);
                    
                } ;
                obj.ImageUrl = @"\Images\Books\"+fileName;
            }

            _db.Update(obj);
            _db.SaveChanges();



            return RedirectToAction("Index");   
                }


        [HttpGet]
        public IActionResult BookDelete(int? id)
        {
            var data = _db.Books.FirstOrDefault(u=>u.Id == id);





            return View(data);
        }


        [HttpPost]
        public IActionResult BookDelete(BookModel obj)
        {
            _db.Books.Remove(obj);
            _db.SaveChanges();





            return RedirectToAction("Index");
        }

    }



}

