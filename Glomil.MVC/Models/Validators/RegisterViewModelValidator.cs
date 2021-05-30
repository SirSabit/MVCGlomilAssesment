using FluentValidation;

namespace Glomil.MVC.Models.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Maxium name length can not be over 40 characters!")
                .NotEmpty().WithMessage("Name can not be empty").NotNull().WithMessage("Name can not be null");

            RuleFor(x => x.Surname).MaximumLength(40).WithMessage("Maxium Surname length can not be over 40 characters!")
                .NotEmpty().WithMessage("Surame can not be empty").NotNull().WithMessage("Surame can not be null");

            RuleFor(x => x.NickName).MaximumLength(40).WithMessage("Maxium Nickname length can not be over 40 characters!")
                .NotEmpty().WithMessage("Nickame can not be empty").NotNull().WithMessage("Nickname can not be null");

            RuleFor(x => x.Password).MaximumLength(40).WithMessage("Maxium password length can not be over 50 characters!").NotEmpty().NotNull().WithMessage("Password Can not be empty or null!").Equal(x => x.PasswordCheck).WithMessage("Passwords doesn't match!");
            RuleFor(x => x.PasswordCheck).MaximumLength(40).WithMessage("Maxium password length can not be over 50 characters!").NotEmpty().NotNull().WithMessage("Password Can not be empty or null!").Equal(x => x.Password).WithMessage("Passwords doesn't match!");

        }
    }
}
