using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.To).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.From).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş olamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Bu alan boş olamaz");
        }
    }
}
