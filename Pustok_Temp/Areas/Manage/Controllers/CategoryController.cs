using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Temp.DAL;
using Pustok_Temp.Models;

namespace Pustok_Temp.Areas.Manage.Controllers
{
            [Area("Manage")]
    public class CategoryController : Controller
    {
        AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

            public IActionResult Index()
            {
                List<Categories> categories = _context.categories.ToList();

                return View(categories);
            }

            public IActionResult Create()
            {

                return View();

            }


            [HttpPost]
            public IActionResult Create(Categories category)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _context.categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            public IActionResult Update(int id)
            {

                Categories category = _context.categories.Find(id);
                return View(category);
            }

            [HttpPost]
            public IActionResult Update(Categories newcategory)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Categories oldcategory = _context.categories.Find(newcategory.Id);
                if (oldcategory == null)
                {
                    return View();
                }
                oldcategory.Name = newcategory.Name;
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            public IActionResult Delete(int id)
            {

                Categories category = _context.categories.Find(id);

                if (category != null)
                {
                    _context.categories.Remove(category);
                    _context.SaveChanges();

                }

                return RedirectToAction("Index");
            }
        }
    }