using Library.Models;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Library.IRepository
{
    public interface IBookRepository
    {

        Task<Book> GetAsync(Expression<Func<Book, bool>> expression,string? includeProperity=null);
        Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>>? expression=null, string? includeProperity=null,string? search=null);
        Task AddAsync(Book book);
        Task RemoveAsync(Book book);
        Task UpdateAsync(Book book);
        Task UploadImageAsync(Book book,IFormFile file);
        void DeleteImage(string image);
        Task UploadPdfFileAsync(Book book,IFormFile pdfFile);
        void DeletePdfFile(Book book);

    }
}
