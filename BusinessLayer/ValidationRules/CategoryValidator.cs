using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez !");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez !");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı 3 karakterden az olamaz !");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori adı maksimum 20 karakter olmalı.");
        }
    }
}
