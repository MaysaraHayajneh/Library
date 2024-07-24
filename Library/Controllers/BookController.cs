using Library.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.Localization;
using System;
using System.Globalization;


namespace Library.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IShelfRepository _shelfRepository;
        public BookController(IBookRepository bookRepository, IShelfRepository shelfRepository)
        {
            _bookRepository = bookRepository;
            _shelfRepository = shelfRepository;          
        }

       
       
        public async Task<IActionResult> Index(int? ShelfId)
        {  
            
             List<Book> books = await _bookRepository.GetAllAsync(includeProperity: "shelf");
                    
            if(ShelfId!= null)
            {
                books=books.Where(o=>o.ShelfId==ShelfId).ToList();
                if (books.Count == 0)
                {
                    TempData["error"] = "there is no books in the shelf now";
                    return RedirectToAction("Index", "Shelf");
                }
            }
            ViewBag.hasShelfId = ShelfId;            
                   return View(books);

        }
      
        public async Task <IActionResult> Add(int? shelfId)
        {      
            List<Shelf> shelves =await _shelfRepository.GetAllAsync();
            if (shelfId != null)
            {
                shelves = shelves.Where(o => o.Id == shelfId).ToList();
            }
            
            ViewBag.ShelvesList = new List<SelectList>()
            {
                new SelectList(shelves, "Id", "EnglishName"),
                new SelectList(shelves, "Id", "ArabicName"),
                new SelectList(shelves, "Id", "FrenchName"),
            };

            return View(new Book());  
        }

        [HttpPost]
        
        public async Task<IActionResult> Add(Book newBook)
        {
            if (ModelState.IsValid)
            {
                
                if (!newBook.pdfFormFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                {
                    ViewBag.message = "Only pdf files allowed";
                    return View(newBook);
                }
               await _bookRepository.UploadImageAsync(newBook, newBook.ImgFormFile);
               await _bookRepository.UploadPdfFileAsync(newBook, newBook.pdfFormFile);
               await _bookRepository.AddAsync(newBook);
                var shelf = await _shelfRepository.GetAsync(o=>o.Id==newBook.ShelfId);
                shelf.BookCount +=1;
                await _shelfRepository.UpdateAsync(shelf);

                return RedirectToAction("Index",new { ShelfId=newBook.ShelfId});

            } else 
            {
               
                List<Shelf> shelves = await _shelfRepository.GetAllAsync();
                var lookups=
                ViewBag.ShelvesList = new List<SelectList>()
                {
                new SelectList(shelves, "Id", "EnglishName"),
                new SelectList(shelves, "Id", "ArabicName"),
                new SelectList(shelves, "Id", "FrenchName"),
                };
                return View(newBook);
            };
        }

        public async Task<IActionResult> Edit(int?Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Book editedBook =await _bookRepository.GetAsync(o=>o.Id==Id,includeProperity:"shelf");
            ViewBag.img = editedBook.ImgFormFile;
            List<Shelf> shelves = await _shelfRepository.GetAllAsync();
            ViewBag.ShelvesList = new List<SelectList>()
                {
                new SelectList(shelves, "Id", "EnglishName"),
                new SelectList(shelves, "Id", "ArabicName"),
                new SelectList(shelves, "Id", "FrenchName"),
            };
            return View(editedBook);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Book? editedBook)
        {
            

            if (editedBook == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                 if (!editedBook.pdfFormFile.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                 {
                     ViewBag.message = "only pdf files allowed";
                     return View(editedBook);
                 }
                await _bookRepository.UploadImageAsync(editedBook, editedBook.ImgFormFile);
                await _bookRepository.UploadPdfFileAsync(editedBook, editedBook.pdfFormFile);
                await _bookRepository.UpdateAsync(editedBook);              
                return RedirectToAction("Index", new { ShelfId = editedBook.ShelfId });
            }
            else
            {
                ViewBag.message = "please choase a file";
                List<Shelf> shelves = await _shelfRepository.GetAllAsync();
                ViewBag.Shelveslist = new List<SelectList>()
                {
                    new SelectList(shelves,"Id","EnglishName"),
                    new SelectList(shelves,"Id","ArabicName"),
                    new SelectList(shelves,"Id","FrenchName"),

                };
                return View(editedBook);
            }
        }
        public async Task<IActionResult> Delete(int?Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Book deletedBook =await _bookRepository.GetAsync(o => o.Id == Id);
            List<Shelf> shelves=await _shelfRepository.GetAllAsync();

            ViewBag.Shelveslist = shelves.Where(o => o.Id == deletedBook.ShelfId).Select(o => new SelectListItem()
            {
                Text = o.EnglishName,
                Value = o.Id.ToString(),
            });

            return View(deletedBook);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Book deletedBook)
        {
            if (deletedBook == null)
            {
                return NotFound();
            }
            _bookRepository.DeletePdfFile(deletedBook);
            _bookRepository.DeleteImage(deletedBook.Image);
            await _bookRepository.RemoveAsync(deletedBook);
            var shelf = await _shelfRepository.GetAsync(o => o.Id == deletedBook.ShelfId);
            shelf.BookCount -= 1;
            await _shelfRepository.UpdateAsync(shelf);
            return RedirectToAction("Index", new { ShelfId = deletedBook.ShelfId });
          
        }
        

        #region API CALLS
        [HttpGet]

        public async Task<IActionResult> GetAllBooks(int? ShelfId)
        {
            
            List<Book> books = await _bookRepository.GetAllAsync(includeProperity: "shelf");

            if (ShelfId != null)
            {
                books = books.Where(o => o.ShelfId == ShelfId).ToList();
                if (books.Count == 0)
                {
                    TempData["error"] = "there is no books in the shelf now";
                    return RedirectToAction("Index", "Shelf");
                }
            }
            ViewBag.hasShelfId = ShelfId;
            return Json(new { data = books });

        }
        #endregion

    }


}
