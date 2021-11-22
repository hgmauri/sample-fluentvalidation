using System.Globalization;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection; 

namespace Sample.FluentValidation.WebApi.Core.Extensions;

public static class FluentValidationExtension
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services, Type assemblyContainingValidators)
    {
        services.AddFluentValidation(conf =>
        {
            conf.RegisterValidatorsFromAssemblyContaining(assemblyContainingValidators);
            conf.AutomaticValidationEnabled = false;
            conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
        });

        return services;
    }

    public static List<MessageResult>? GetErrors(this ValidationResult result)
    {
        return result.Errors?.Select(error => new MessageResult(error.PropertyName, error.ErrorMessage)).ToList();
    }
}
