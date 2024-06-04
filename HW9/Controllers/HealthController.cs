using Microsoft.AspNetCore.Mvc;

namespace HW9.Controllers;

[ApiController]
[Route("orderservice/[controller]")]
public class HealthController(ILogger<HealthController> logger) : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        logger.LogInformation($"{nameof(HW9)}->{nameof(GetHealth)}' was called");
        return Ok(new { status = $"{nameof(HW9)}: OK" });
    }
}
