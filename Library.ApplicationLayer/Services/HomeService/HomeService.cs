using Library.IRepository;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.HomeService
{
    internal class HomeService : IHomeService
    {

        private readonly IShelfRepository _shelfRepository;
        private readonly IBookRepository _bookRepository;
        public HomeService(IShelfRepository shelfRepository, IBookRepository bookRepository)
        {
            _shelfRepository = shelfRepository;
            _bookRepository = bookRepository;
        }
        public async Task<List<Book>> GetBook(int? Id)
        {
            List<Shelf> shelves = await _shelfRepository.GetAllAsync();
        }

        public async Task<List<Book>> GetBooksByShelfIdService(int? ShelfId)
        {
            List<Book> books = await _bookRepository.GetAllAsync(o => o.ShelfId == ShelfId, includeProperity: "shelf"); ;
        }

        public async Task<List<Shelf>> GetShelvesService()
        {
            Book book = await _bookRepository.GetAsync(o => o.Id == Id);
        }
    }
}
