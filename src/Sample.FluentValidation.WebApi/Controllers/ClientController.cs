using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Sample.FluentValidation.WebApi.Core.Extensions;
using Sample.FluentValidation.WebApi.Core.ViewModels;

namespace Sample.FluentValidation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IValidator<ClientViewModel> _validator;

    public ClientController(IValidator<ClientViewModel> validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientViewModel model)
    {
        var validation = await _validator.ValidateAsync(model);

        if (!validation.IsValid)
        {
            return BadRequest(validation.GetErrors());
        }

        return Ok();
    }
}
