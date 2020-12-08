using FluentValidation;
using FMS.Domain.Models;

namespace FMS.ServiceLayer.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        string _cantBeEmpty = "Kohustuslik väli";

        public CustomerValidator()
        {
            //CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Name).NotEmpty().WithMessage(_cantBeEmpty)
                .MaximumLength(70).WithMessage("Max pikkus 70");
            RuleFor(c => c.RegNo).NotEmpty().WithMessage(_cantBeEmpty)
                .MaximumLength(20).WithMessage("Max pikkus 20");
            RuleFor(c => c.VATNo).MaximumLength(20).WithMessage("Max pikkus 20");
            RuleFor(c => c.PaymentTermId).NotEmpty().WithMessage(_cantBeEmpty);
            RuleFor(c => c.DeliveryTermText).MaximumLength(50).WithMessage("Max pikkus 50");

            RuleForEach(c => c.Contacts).SetValidator(new CustomerContactValidator());
            RuleForEach(c => c.Addresses).SetValidator(new CustomerAddressValidator());
        }
    }

    public class CustomerContactValidator : AbstractValidator<CustomerContact>
    {
        string _cantBeEmpty = "Kohustuslik väli";

        public CustomerContactValidator()
        {
            //CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Name).NotEmpty().WithMessage(_cantBeEmpty)
                .MaximumLength(50).WithMessage("Max pikkus 50");
            RuleFor(c => c.Job).MaximumLength(50).WithMessage("Max pikkus 50");
            RuleFor(c => c.Mobile).MaximumLength(30).WithMessage("Max pikkus 30");
            RuleFor(c => c.Phone).MaximumLength(20).WithMessage("Max pikkus 20");
            RuleFor(c => c.Email).MaximumLength(100).WithMessage("Max pikkus 100");
        }
    }

    public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
    {
        string _cantBeEmpty = "Kohustuslik väli";

        public CustomerAddressValidator()
        {
            //CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.CountryId).NotEqual(0).WithMessage(_cantBeEmpty);
            RuleFor(c => c.County).MaximumLength(50).WithMessage("Max pikkus 30");
            RuleFor(c => c.City).NotEmpty().WithMessage(_cantBeEmpty)
                .MaximumLength(50).WithMessage("Max pikkus 50");
            RuleFor(c => c.Address).NotEmpty().WithMessage(_cantBeEmpty)
                .MaximumLength(100).WithMessage("Max pikkus 100");
            RuleFor(c => c.PostCode).MaximumLength(10).WithMessage("Max pikkus 10");
            RuleFor(c => c.Description).MaximumLength(50).WithMessage("Max pikkus 50");
        }
    }
}
