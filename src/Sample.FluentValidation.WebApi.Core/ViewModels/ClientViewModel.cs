using FluentValidation;

namespace Sample.FluentValidation.WebApi.Core.ViewModels;

public class ClientViewModel
{
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public IList<ProductViewModel>? Products { get; set; }
}

public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
{
    public ClientViewModelValidator()
    {
        When(x => x == null, () =>
        {
            RuleFor(x => x).NotNull();
        }).Otherwise(() =>
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();

            RuleFor(person => person.BirthDate).LessThan(DateTime.Now.AddYears(-18)).WithMessage("Cliente menor que 18 anos");

            RuleForEach(x => x.Products).NotNull();
        });
    }
}
