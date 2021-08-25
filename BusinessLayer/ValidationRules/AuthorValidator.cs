using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı boş geçilemez !");
            RuleFor(x => x.AuthorSurname).NotEmpty().WithMessage("Yazar soyadı geçilemez !");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Hakkımda kısmı boş geçilemez !");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazar unvanı boş geçilemez !");
            RuleFor(x => x.AuthorSurname).MinimumLength(2).WithMessage("Yazar soyadı 2 karakterden az olamaz !");
            RuleFor(x => x.AuthorSurname).MaximumLength(50).WithMessage("Yazar soyadı maksimum 50 karakter olmalı.");

        }
    }
}
