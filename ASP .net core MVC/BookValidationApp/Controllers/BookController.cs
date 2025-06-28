using BookValidationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookValidationApp.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> bookList = new List<Book>();

        public IActionResult Index()
        {
            return View(bookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            // Unique ISBN check
            if (bookList.Any(b => b.Isbn == book.Isbn))
            {
                ModelState.AddModelError("Isbn", "ISBN must be unique.");
            }

            if (ModelState.IsValid)
            {
                bookList.Add(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}

