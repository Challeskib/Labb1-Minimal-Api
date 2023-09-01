using Labb1_Minimal_Api.Data;
using Labb1_Minimal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_Minimal_Api.Services
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            foreach (var item in _context.Authors)
            {
                Console.WriteLine(item.Name);
            }
            return await _context.Authors.ToListAsync();

        }

        public async Task<Author> GetById(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> Create(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Delete(int id)
        {
            var authorToDelete = await _context.Authors.FindAsync(id);

            _context.Authors.Remove(authorToDelete);
            await _context.SaveChangesAsync();
            return authorToDelete;
        }
    }
}
