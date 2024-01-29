using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CarReviewCommands;

namespace UdemyCarBook.Application.Validators.CarReviewValidators;

public class CreateCarReviewValidator : AbstractValidator<CreateCarReviewCommand>
{
    public CreateCarReviewValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz.");
        RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakterli veri girişi yapınız.");
        RuleFor(x => x.RaytingValues).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz.");
    }
}
