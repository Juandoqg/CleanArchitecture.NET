using CL_InterfaceAdapters_Mappers.DTO.Requests;
using FluentValidation;

namespace CL_FrameworksDriver_API.Validators
{
    public class BeerValidator : AbstractValidator<BeerRequestDTO>
    {
        public BeerValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("La cerveza debe tener nombre");
            RuleFor(dto => dto.Style).NotEmpty().WithMessage("La cerveza debe tener un estilo");
            RuleFor(dto => dto.Alcohol).GreaterThan(0).WithMessage("El alcohol debe ser mayor a 0");


        }
    }
}
