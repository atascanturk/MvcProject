using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator :AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen minimum 3 karakter girişi yapınız.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen maksimum 50 karakter girişi yapınız.");
           
        }
    }
}
