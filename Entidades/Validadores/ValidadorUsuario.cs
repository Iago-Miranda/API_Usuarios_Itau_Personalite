using Entidades.Entidades;
using FluentValidation;

namespace Entidades.Validadores
{
    public class ValidadorUsuario : AbstractValidator<Usuario>
    {
        public ValidadorUsuario()
        {
            RuleFor(usuario => usuario.Nome)
                .NotNull().WithMessage("O nome do usuário é obrigatório!")
                .MinimumLength(3).WithMessage("O campo nome deve conter ao menos 3 letras!");

            RuleFor(usuario => usuario.Email)
                .NotNull().WithMessage("O e-mail do usuário é obrigatório!")
                .EmailAddress().WithMessage("O formato do email está inválido!");

            RuleFor(usuario => usuario.Senha)
                .NotNull().WithMessage("Favor informar a senha do usuário!")
                .MinimumLength(8).WithMessage("O comprimento mínimo da senha é de 8 caracteres!");
        }
    }
}
