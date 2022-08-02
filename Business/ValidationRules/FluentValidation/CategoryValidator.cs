using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz");
            RuleFor(p => p.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır");
        }
    }
}
