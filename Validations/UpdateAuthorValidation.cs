using FluentValidation;
using Labb1_Minimal_Api.Models;

namespace Labb1_Minimal_Api.Validations
{
    public class UpdateAuthorValidation : AbstractValidator<Author>
    {
        public UpdateAuthorValidation()
        {
            RuleFor(model => model.Name).NotEmpty();

        }
    }
}
