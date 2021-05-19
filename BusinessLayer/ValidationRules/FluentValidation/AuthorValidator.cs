using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AuthorValidator :AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(a => a.LastName).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(a => a.Title).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(a => a.About).NotEmpty().WithMessage("Hakkında alanı boş geçilemez.");
            RuleFor(a => a.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(a => a.LastName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(a => a.Name).MaximumLength(20).WithMessage("Lütfen maksimum 20 karakter giriniz.");
            RuleFor(a => a.LastName).MaximumLength(20).WithMessage("Lütfen maksimum 20 karakter giriniz.");
        }
    }
}
