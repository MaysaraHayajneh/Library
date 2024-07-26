using Library.Data;
using Library.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookRepository(LibraryDbContext libraryDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _db = libraryDbContext;
            this._webHostEnvironment = webHostEnvironment;
        }
        public async Task AddAsync(Book book)
        {
            await _db.books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public void DeleteImage(string image)
        {
            if (image != null)
            {
                var imgePath = Path.Combine(_webHostEnvironment.WebRootPath, image.TrimStart('\\'));
                var fileInfo=new FileInfo(imgePath);
                if (fileInfo.Exists)
                    fileInfo.Delete();
            }
        }

        public void DeletePdfFile(Book book)
        {
            if (book.pdfFileName!=null)
            {
                var realPath = Path.Combine(_webHostEnvironment.WebRootPath, "pdfFiles", book.pdfFileName);
                var FileInfo=new FileInfo(realPath);
                if(FileInfo.Exists)
                    FileInfo.Delete();
            }
            
        }

        public async Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>>? expression = null, string? includeProperity = null,string? searchName=null)
        {

            IQueryable<Book> books = _db.books;
            if (expression != null)
            {
                books = books.Where(expression);
            }
            if (includeProperity != null)
            {
                books = books.Include(includeProperity);
            }
            if(searchName != null)
            {
                books = books.Where(o => o.Name.Contains(searchName));
            }
            return await books.ToListAsync();
        }

        public async Task<Book> GetAsync(Expression<Func<Book, bool>> expression, string? includeProperity = null)
        {
            IQueryable<Book> book = _db.books.Where(expression);
            if (includeProperity != null)
            {
                book = book.Include(includeProperity);
            }
            return await book.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Book book)
        {
            _db.books.Remove(book);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _db.books.Update(book);
            await _db.SaveChangesAsync();
        }

        public async Task UploadImageAsync(Book book,IFormFile file)
        {
           
               
                   var FilePath = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\Book");
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }
                    var fileName = Guid.NewGuid().ToString()+ Path.GetFileName(file.FileName);
                    if (!string.IsNullOrEmpty(book.Image))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, book.Image.TrimStart('\\'));
                        var fileInfo=new FileInfo(oldImagePath);
                        if(fileInfo.Exists)
                            fileInfo.Delete();
                    }
                      var Stream = new FileStream(Path.Combine(FilePath, fileName), FileMode.Create);
                      await file.CopyToAsync(Stream);
                        Stream.Close();
                    book.Image =@"\Images\Book\" + fileName;
        }

        public async Task UploadPdfFileAsync(Book book, IFormFile pdfFile)

        {
            var pdfPath = Path.Combine(_webHostEnvironment.WebRootPath, "pdfFiles");
            if (!Directory.Exists(pdfPath))
            {
                Directory.CreateDirectory(pdfPath);
            }
            var fileName= Guid.NewGuid().ToString()+Path.GetFileName(pdfFile.FileName);
            DeletePdfFile(book);
            var Stream = new FileStream(Path.Combine(pdfPath, fileName), FileMode.Create);
            await pdfFile.CopyToAsync(Stream);
            Stream.Close();

            //read pdf fileContent into a byte array

           var memoryStream= new MemoryStream();
           await pdfFile.CopyToAsync(memoryStream);
            book.pdfContent = memoryStream.ToArray();
            book.pdfFileName= fileName;
            memoryStream.Close();
        }
    }
}
