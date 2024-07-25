using Library.Application.Services.HomeService;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Library.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IHomeService _homeService;

        public HomeController(IStringLocalizer<SharedResource> stringLocalizer,IHomeService homeService)
        {
           
            this._stringLocalizer = stringLocalizer;
            this._homeService = homeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _homeService.GetShelvesService());
        }

        public async Task<IActionResult> DisplayBook(int? ShelfId)
        {
            var books=await _homeService.GetBooksByShelfIdService(ShelfId); 
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
            var book = await _homeService.GetBook(Id);

            if (Id == null || book.pdfContent == null || book.pdfContent.Length == 0)
            {
                var message = _stringLocalizer["the book is unavaliable"];
                TempData["error"] = message.Value;
                return RedirectToAction("DisplayBook", "Home",new {ShelfId=book.ShelfId});
            }  

            var memory=new MemoryStream(book.pdfContent);
            return File(memory, "application/pdf", book.pdfFileName);
        }

        public IActionResult ShowBooksAvalizableInChart()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<object>> GetBooksData()
        {
            return (await _homeService.GetBookNameAndCount());
            
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
