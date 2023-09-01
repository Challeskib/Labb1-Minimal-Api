using Azure;
using Labb1_Minimal_Api.Data;
using Labb1_Minimal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_Minimal_Api.Services
{
    public class BookRepository : IRepository<Book>
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();

        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> Create(Book book)
        {

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Delete(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);

            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return bookToDelete;
        }
    }
}
