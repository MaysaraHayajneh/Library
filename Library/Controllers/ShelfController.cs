using Library.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace Library.Controllers

{
    [Authorize(Roles ="Admin")]
    
    public class ShelfController : Controller
    {
        private readonly IShelfRepository _shelfRepository;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public ShelfController(IShelfRepository shelfRepository,IStringLocalizer<SharedResource> stringLocalizer )
        {
            _shelfRepository = shelfRepository;
            this._stringLocalizer = stringLocalizer;
        }
         
        public async Task<IActionResult> Index()

        {
             List<Shelf> shelves = await _shelfRepository.GetAllAsync();

                return View(shelves);
           
        }

        public IActionResult Add()
        {
                return View(new Shelf());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Shelf newShelf)
        {
            if (ModelState.IsValid)
            {
                await _shelfRepository.AddAsync(newShelf);
                var errorMessage = _stringLocalizer["Shelf has been added successfuly"];
                TempData["success"] = errorMessage.Value;
                return RedirectToAction("Index");
            }
            else
            {
                return View(newShelf);
            }
        }

        public async Task<IActionResult> Edit(int?Id)
        {
            if (Id != null)
            {
                Shelf editedShelf = await _shelfRepository.GetAsync(o => o.Id == Id);
                return View(editedShelf);
            }
            else return NotFound();
        }
        [HttpPost]

        public async Task<IActionResult> Edit(Shelf shelfEdited)
        {
            if (shelfEdited == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
               await _shelfRepository.UpdateAsync(shelfEdited);
                var errorMessage = _stringLocalizer["Shelf has been Edited successfuly"];
                TempData["success"] = errorMessage.Value;
                return RedirectToAction("Index");
            }else return View(shelfEdited);
        }


        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var shelfDeleted = await _shelfRepository.GetAsync(O => O.Id == Id);
            return View(shelfDeleted);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Shelf? deletedShelf)
        {
            if (deletedShelf == null)
            {
                return NotFound();
            }
            await _shelfRepository.RemoveAsync(deletedShelf);
            var errorMessage = _stringLocalizer["Shelf has been deleted successfuly"];
            TempData["success"] = errorMessage.Value;
            return RedirectToAction("Index");

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CulturManagement(string Culture, string returnURl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Culture))
                ,new CookieOptions { Expires=DateTimeOffset.Now.AddDays(30)});
            return LocalRedirect(returnURl);
        }


    }
}
