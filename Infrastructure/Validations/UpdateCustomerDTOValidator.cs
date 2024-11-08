
using FluentValidation;
using Core.DTOs;

public class UpdateCustomerDTOValidator : AbstractValidator<UpdateCustomerDTO>
{
    public UpdateCustomerDTOValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("El Id del cliente es obligatorio y debe ser mayor que 0.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("El nombre completo es obligatorio.")
            .Length(2, 50).WithMessage("El nombre completo debe tener entre 5 y 100 caracteres.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("El nombre completo es obligatorio.")
            .Length(3, 100).WithMessage("El nombre completo debe tener entre 5 y 100 caracteres.");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("El correo electrónico no es válido.")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Phone)
            .Matches(@"^\+?\d{1,4}$").WithMessage("Error")
            .WithMessage("El número de teléfono no es válido.")
            .When(x => !string.IsNullOrEmpty(x.Phone));

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now).WithMessage("Nacimiento debe ser en el pasado")
            .When(x => x.BirthDate.HasValue);
    }
}
