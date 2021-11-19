using FluentValidation;

namespace Sample.FluentValidation.WebApi.Core.ViewModels;

public class ClientViewModel
{
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public IList<ProductViewModel>? Products { get; set; }
}

public class RemanejaOrdemConsultaValidator : AbstractValidator<ClientViewModel>
{
    public RemanejaOrdemConsultaValidator()
    {
        When(x => x != null, () =>
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();

            RuleForEach(x => x.Products).NotNull();

            RuleFor(person => person.BirthDate).LessThan(DateTime.Now.AddYears(-18)).WithMessage("Cliente menor que 18 anos");
        });
    }
}
