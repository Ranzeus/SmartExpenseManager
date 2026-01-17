using Microsoft.AspNetCore.Mvc;

namespace SmartExpenseManager.API.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
        => Ok("API is running");
}
