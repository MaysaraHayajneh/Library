using Library.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.BookService
{

    internal class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IShelfRepository _shelfRepository;
        public BookService(IBookRepository bookRepository, IShelfRepository shelfRepository)
        {
            _bookRepository = bookRepository;
            _shelfRepository = shelfRepository;
        }
    }
}
