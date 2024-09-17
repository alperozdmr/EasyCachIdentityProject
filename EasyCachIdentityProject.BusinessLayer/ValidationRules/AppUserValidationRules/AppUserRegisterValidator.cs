using FluentValidation;
using EasyCachIdentityProject.DtoLayer.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapın");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parola eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli mail adresi girin");
        }
    }
}
