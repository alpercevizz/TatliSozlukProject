using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mail adresini boş geçemezsiniz !");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj konusunu boş geçemezsiniz !");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajınızı boş geçemezsiniz !");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Mesaj konusu 3 karakterden az olamaz !");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Mesaj konusu maksimum 100 karakter olmalı.");
        }
    }
}
