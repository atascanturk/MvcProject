using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Lütfen maksimum 20 karakter giriniz.");
        }
    }
}
