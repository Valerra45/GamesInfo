using FluentValidation;
using GamesInfo.Application.Services.Games.Commands;

namespace GamesInfo.Application.Services.Games.Validators
{
    public class CreateGameValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameValidator()
        {
            RuleFor(p => p.Request.Name)
               .NotEmpty()
               .WithMessage("{PropertyName} is not assigned");

            RuleFor(p => p.Request.Description)
               .NotEmpty()
               .WithMessage("{PropertyName} is not assigned");
        }
    }
}
