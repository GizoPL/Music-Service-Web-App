using System.Linq;
using Dtos;
using FluentValidation;
using MyFirstWebApp.Repository;

namespace Repository.Validators
{
    public class SupplierRegisterDtoValidator : AbstractValidator<SupplierRegisterDto>
    {
        public SupplierRegisterDtoValidator(MusicContext _context)
        {
            RuleFor(x=>x.UserName)
                .NotEmpty();

            RuleFor(x => x.UserName)
                .Custom((value, context) => {
                    var userNameInUse = _context.Suppliers.Any(p => p.UserName == value);
                    if(userNameInUse)
                    {
                        context.AddFailure("UserName", "That username is taken");
                    }
                });   

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Email)
                .Custom((value, context) => {
                    var emailInUse = _context.Suppliers.Any(p => p.Email == value);
                    if(emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });   

            RuleFor(x => x.Password)
                .MinimumLength(6);
            
            RuleFor(x => x.ConfirmPassword)
                .Equal(y => y.Password);

        }
    }
}