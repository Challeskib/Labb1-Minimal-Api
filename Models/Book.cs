using System.Text.Json.Serialization;

namespace Labb1_Minimal_Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool LoanAble { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
