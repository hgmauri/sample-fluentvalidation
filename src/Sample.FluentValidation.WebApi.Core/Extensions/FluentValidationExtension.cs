using System.Globalization;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection; 

namespace Sample.FluentValidation.WebApi.Core.Extensions;

public static class FluentValidationExtension
{
    public static IServiceCollection AddFluentValidation(this IServiceCollection services, Type assemblyContainingValidators)
    {
        services.AddFluentValidation(conf =>
        {
            conf.RegisterValidatorsFromAssemblyContaining(assemblyContainingValidators);
            conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
        });

        return services;
    }
}
