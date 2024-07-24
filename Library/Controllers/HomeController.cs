using Library.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Library.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IShelfRepository _shelfRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public HomeController(IShelfRepository shelfRepository, IBookRepository bookRepository,IStringLocalizer<SharedResource> stringLocalizer)
        {
            _shelfRepository = shelfRepository;
            _bookRepository = bookRepository;
            this._stringLocalizer = stringLocalizer;
        }
        public async Task<IActionResult> Index()
        {
            List<Shelf> shelves=await _shelfRepository.GetAllAsync();
            return View(shelves);
        }

        public async Task<IActionResult> DisplayBook(int? ShelfId)
        {

            List<Book> books=await _bookRepository.GetAllAsync(o=>o.ShelfId==ShelfId,includeProperity:"shelf");
            if (books.Count == 0)
            {
                var errorMessage = _stringLocalizer["There is no books in this shelf"];
                TempData["error"] = errorMessage.Value;
                return RedirectToAction("Index", "Home");
            }
            return View(books);
        }

        public async Task<IActionResult> downloadPdf(int? Id)
        {
            Book book = await _bookRepository.GetAsync(o => o.Id == Id);

            if (Id == null || book.pdfContent == null || book.pdfContent.Length == 0)
            {
                var message = _stringLocalizer["the book is unavaliable"];
                TempData["error"] = message.Value;
                return RedirectToAction("DisplayBook", "Home",new {ShelfId=book.ShelfId});
            }  

            var memory=new MemoryStream(book.pdfContent);
            return File(memory, "application/pdf", book.pdfFileName);
        }

        public async Task<IActionResult> ShowBooksAvalizableInChart()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<object>> GetBooksData()
        {
            List<object> data = new List<object>();
            var shelves =await _shelfRepository.GetAllAsync();
           

            List<string> label=shelves.Select(s=>s.EnglishName).ToList();
            data.Add(label);
            List<int> count=shelves.Select(s=>s.BookCount).ToList();
            data.Add(count);


            return data;
        }
      

        public IActionResult Privacy()
        {
            return View();
        }  
        public IActionResult Chat()
        {
            return View();
        }
    

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



     


    }
}
