using FluentValidation;
using HastaneListesiApp.Core.DTOs.RequestDtos;

namespace HastaneListesiApp.Services.Validations
{
    public class HospitalRequestDtoValidator : AbstractValidator<HospitalRequestDto>
    {
        public string RequiredMessage
        {
            get
            {
                return "{PropertyName} alan adı Gerekli";
            }
        }
        public HospitalRequestDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage(RequiredMessage).NotNull().WithMessage(RequiredMessage);
            RuleFor(a => a.CityId).NotNull().WithMessage(RequiredMessage).NotEmpty().WithMessage(RequiredMessage);
        }
    }
}
