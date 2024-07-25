using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.HomeService
{
    public interface IHomeService
    {
        public Task<List<Shelf>> GetShelvesService();
        public Task<List<Book>> GetBooksByShelfIdService(int? ShelfId);
        public Task<Book> GetBook(int? Id);
        public Task<List<Object>> GetBookNameAndCount();


    }
}
