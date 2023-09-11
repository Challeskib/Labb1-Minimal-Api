namespace Labb1_Minimal_Api.Models.DTOS
{
    public class EditBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool LoanAble { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
