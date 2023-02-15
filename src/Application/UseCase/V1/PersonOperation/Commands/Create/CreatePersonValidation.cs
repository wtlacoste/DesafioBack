﻿using FluentValidation;

namespace DesafioBackendAPI.Application.UseCase.V1.PersonOperation.Commands.Create
{
    public class CreatePersonValidation : AbstractValidator<CreatePersonCommand>
    {

        public CreatePersonValidation()
        {
            RuleFor(x => x.Apellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Apellido is invalid")
                .MaximumLength(12)
                .WithMessage("Apellido solo puede tener 255 caracteres");
            RuleFor(x => x.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Nombre is invalid")
                .MaximumLength(255)
                .WithMessage("Nombre solo puede tener 255 caracteres");
        }
    }
}
