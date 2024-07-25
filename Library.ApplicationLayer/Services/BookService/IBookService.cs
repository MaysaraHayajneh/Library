using Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.BookService
{
    internal interface IBookService
    {
        public Task<List<Book>> GetAllBooksService();
        public Task<List<Shelf>> GetShelvesServise(int? shelfId);
        public void UploadImageAndFielAsyncSrvice(Book book,IFormFile formFile);
        
    }
}
