using Core.DTOs;
using FluentValidation;

namespace WebApi.Validations
{
    

public class CreateCustomerDTOValidator : AbstractValidator<CreateCustomerDTO>
    {
        public CreateCustomerDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .Length(5, 100).WithMessage("El nombre completo debe tener entre 5 y 100 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido  es obligatorio.")

                .Length(5, 100).WithMessage("El nombre completo debe tener entre 5 y 100 caracteres.");


            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El correo electrónico no es válido.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Phone)
                .Matches(@"^\+?\d{1,4}[\s\-]?\(?\d+\)?[\s\-]?\d{1,4}[\s\-]?\d{1,4}[\s\-]?\d{1,4}$")
                .WithMessage("El número de teléfono no es válido.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now).WithMessage("Nacimiento debe ser en el pasado")
            .When(x => x.BirthDate.HasValue);
        }
    }

}

