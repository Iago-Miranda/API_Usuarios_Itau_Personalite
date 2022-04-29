using Entidades.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIAutenticacao.Models;

namespace WebAPIAutenticacao.Validadores
{
    public class ValidadorLogin : AbstractValidator<Login>
    {
        public ValidadorLogin()
        {
            RuleFor(login => login.Email)
                .NotNull().WithMessage("O e-mail do usuário é obrigatório!")
                .EmailAddress().WithMessage("O formato do email está inválido!");

            RuleFor(login => login.Senha)
                .NotNull().WithMessage("Favor informar a senha do usuário!")
                .MinimumLength(8).WithMessage("O comprimento mínimo da senha é de 8 caracteres!");
        }
    }
}
