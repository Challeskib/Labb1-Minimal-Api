using FluentValidation;
using Labb1_Minimal_Api.Models;

namespace Labb1_Minimal_Api.Validations
{
    public class UpdateBookValidation : AbstractValidator<Book>
    {

        public UpdateBookValidation()
        {
            RuleFor(model => model.Year).InclusiveBetween(1, 2023);
            RuleFor(model => model.Title).NotEmpty();
            RuleFor(model => model.AuthorId).NotEmpty();
            RuleFor(model => model.GenreId).NotEmpty();
        }
    }
}
