using Labb1_Minimal_Api.Data;
using Labb1_Minimal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_Minimal_Api.Services
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.ToListAsync();

        }

        public async Task<Genre> GetById(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<Genre> Create(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> Update(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> Delete(int id)
        {
            var genreToDelete = await _context.Genres.FindAsync(id);

            _context.Genres.Remove(genreToDelete);
            await _context.SaveChangesAsync();
            return genreToDelete;
        }
    }
}
