using Library.Models;
using System.Linq.Expressions;

namespace Library.IRepository
{
    public interface IShelfRepository
    {

        Task<Shelf> GetAsync(Expression<Func<Shelf,bool>> expression);
        Task<List<Shelf>> GetAllAsync();
        Task AddAsync(Shelf shelf);
        Task RemoveAsync(Shelf shelf);
        Task UpdateAsync(Shelf shelf);
      

    }
}
