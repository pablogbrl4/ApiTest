using FluentValidation;
using WebTeste.Models;

namespace WebTeste.Validator
{
    public class TodoValidator : AbstractValidator<Todo>
    {
        public TodoValidator()
        {

            RuleFor(t => t.Title).NotEmpty().Length(1, 50)
               .WithMessage("Especifique o Titúlo");

            RuleFor(t => t.Body).NotEmpty().Length(1, 50)
               .WithMessage("Especifique o Body");

            RuleFor(t => t.IsCompleted).NotEmpty()
               .WithMessage("Selecione a Flag");

        }
    }
}
