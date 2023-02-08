﻿using Domain.Entitys.Login;
using Domain.Enums;
using FluentValidation;
using System.Data;

namespace Domain.Validation
{
    public class LogValidationDomain : AbstractValidator<SingOn>
    {
        public LogValidationDomain()
        {
            RuleFor(l => l.Password)
                .NotEmpty()
                    .WithMessage("Senha é obrigatoria")

                .MinimumLength(8)
                    .WithMessage("Senha deve conter pelo menos 8 caracteres")

                .Matches("[A-Z]")
                    .WithMessage("Senha deve conter pelo menos um numero maiúscula")

                .Matches("[a-z]")
                    .WithMessage("Senha deve conter pelo menos uma letra")

                .Matches("[0-9]")
                    .WithMessage("Senha deve conter pelo menos um numero")

                .Matches("[^a-zA-Z0-9]")
                    .WithMessage("Senha deve conter pelo menos um carácter especial");


            RuleFor(l => l.Role)
                .IsEnumName(typeof(Roles), caseSensitive: false)
                    .WithMessage("Concessão Invalida");
        }
    }
}
