using FluentValidation;
using Proje.JWT.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");

        }
    }
}
