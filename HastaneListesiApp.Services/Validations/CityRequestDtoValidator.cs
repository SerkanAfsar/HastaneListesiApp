using FluentValidation;
using HastaneListesiApp.Core.DTOs.RequestDtos;

namespace HastaneListesiApp.Services.Validations
{
    public class CityRequestDtoValidator : AbstractValidator<CityRequestDto>
    {
        public CityRequestDtoValidator()
        {
            RuleFor(a => a.CityName)
                .NotNull().WithMessage("Şehir Adını Giriniz")
                .NotEmpty().WithMessage("Şehir Adını Giriniz");
        }
    }
}
