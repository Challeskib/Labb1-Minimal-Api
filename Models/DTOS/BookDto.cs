using Microsoft.AspNetCore.Mvc.Rendering;

namespace Labb1_Minimal_Api.Models.DTOS
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool LoanAble { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public IEnumerable<Author> Authors { get; set; }

        public Genre Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public int GenreId { get; set; }
    }
}
