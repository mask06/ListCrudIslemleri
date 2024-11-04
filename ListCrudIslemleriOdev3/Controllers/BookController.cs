using ListCrudIslemleriOdev3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListCrudIslemleriOdev3.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>();

        public IActionResult Index()
        {
            return View(books);
        }


        [HttpGet]
        [Route("book/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("book/create")]
        public IActionResult Create(Book book)
        {
            // Id ataması yapalım
            book.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);
            return RedirectToAction("Index");
        }

        // Edit GET
        [HttpGet]
        [Route("book/edit")]
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        // Edit POST
        [HttpPost]
        [Route("book/edit")]
        public IActionResult Edit(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);

                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublishedYear = book.PublishedYear;
                existingBook.Price = book.Price;

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("book/delete")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [Route("book/delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            books.Remove(book);

            return RedirectToAction("Index");
        }
    }
}
