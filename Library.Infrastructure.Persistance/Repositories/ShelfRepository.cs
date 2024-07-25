using Library.Data;
using Library.IRepository;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Repository
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly LibraryDbContext _db;
        public ShelfRepository(LibraryDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task AddAsync(Shelf shelf)
        {
           await _db.shelves.AddAsync(shelf);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Shelf>> GetAllAsync()
        {
            IQueryable<Shelf> shelves =   _db.shelves;
            return await shelves.ToListAsync();
        }

        public async Task<Shelf> GetAsync(Expression<Func<Shelf, bool>> expression)
        {
            IQueryable<Shelf> shelf = _db.shelves.Where(expression);
            
          
            return await shelf.FirstOrDefaultAsync(); 
        }

        public async Task RemoveAsync(Shelf shelf)
        {
            _db.shelves.Remove(shelf);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shelf shelf)
        {
            _db.shelves.Update(shelf);
           await _db.SaveChangesAsync();
        }
    }
}
