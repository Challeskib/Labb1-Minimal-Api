using FluentValidation;
using Labb1_Minimal_Api.Models;
using System.Linq;

namespace Labb1_Minimal_Api.Validations
{
    public class CreateBookValidation : AbstractValidator<Book>
    {
        public CreateBookValidation()
        {
            RuleFor(model => model.Year).InclusiveBetween(1, 2023);
            RuleFor(model => model.Title).NotEmpty();
            RuleFor(model => model.AuthorId).NotEmpty();
            RuleFor(model => model.GenreId).NotEmpty();

        }
    }
}
