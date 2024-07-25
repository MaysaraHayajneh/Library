using Library.IRepository;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.HomeService
{
    public class HomeService : IHomeService
    {

        private readonly IShelfRepository _shelfRepository;
        private readonly IBookRepository _bookRepository;
        public HomeService(IShelfRepository shelfRepository, IBookRepository bookRepository)
        {
            _shelfRepository = shelfRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Book> GetBook(int? Id)
        {
            Book book = await _bookRepository.GetAsync(o => o.Id == Id);
            return book;
        }

        public async Task<List<object>> GetBookNameAndCount()
        {
            List<object> data = new List<object>();
            var shelves = await _shelfRepository.GetAllAsync();


            List<string> label = shelves.Select(s => s.EnglishName).ToList();
            data.Add(label);
            List<int> count = shelves.Select(s => s.BookCount).ToList();
            data.Add(count);


            return data;
        }

        public async Task<List<Book>> GetBooksByShelfIdService(int? ShelfId)
        {
            List<Book> books = await _bookRepository.GetAllAsync(o => o.ShelfId == ShelfId, includeProperity: "shelf"); ;
            return books;
        }

        public async Task<List<Shelf>> GetShelvesService()
        {
            List<Shelf> shelves = await _shelfRepository.GetAllAsync();
            return shelves;
        }

         
    }
}
