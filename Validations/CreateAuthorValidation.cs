using FluentValidation;
using Labb1_Minimal_Api.Models;

namespace Labb1_Minimal_Api.Validations
{
    public class CreateAuthorValidation : AbstractValidator<Author>
    {

        public CreateAuthorValidation()
        {
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}
