using Microsoft.AspNetCore.Mvc;
using Sample.FluentValidation.WebApi.Core.ViewModels;

namespace Sample.FluentValidation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientViewModel model)
    {
        return Ok();
    }
}
