using FluentValidation;
using Labb1_Minimal_Api.Models;
using Labb1_Minimal_Api.Models.DTOS;

namespace Labb1_Minimal_Api.Validations
{
    public class UpdateBookValidation : AbstractValidator<EditBookDto>
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
