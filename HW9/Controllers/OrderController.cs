using System.Text.Json;
using HW9.Dtos;
using HW9.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace HW9.Controllers;

[ApiController]
[Route("orderservice/[controller]")]
public class OrderController(ILogger<OrderController> logger) : ControllerBase
{
    private const string IdempotencyKeyHeader = "Idempotency-Key";

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateOrder(CreateOrderDto dto)
    {
        logger.LogInformation("'{MethodName}' with parameter '{Dto}' was called", nameof(CreateOrder), JsonSerializer.Serialize(dto));

        var idempotencyKeyHeader = HttpContext.Request.Headers.TryGetValue(IdempotencyKeyHeader, out StringValues requestHeader)
            ? requestHeader[0]
            : null;

        if (string.IsNullOrEmpty(idempotencyKeyHeader) || !Guid.TryParse(idempotencyKeyHeader, out Guid idempotencyKey))
        {
            return BadRequest("Idempotency Key is not provided in the request headers");
        }

        var existingOrder = OrderStorage.Get((dto.UserId, idempotencyKey));
        if (existingOrder == null)
        {
            OrderStorage.Store((dto.UserId, idempotencyKey), dto.OrderId);
            return Ok(new { dto.UserId, dto.OrderId, dto.Price });
        }
        else
        {
            return BadRequest("Idempotency key is duplicated");
        }
    }
}
