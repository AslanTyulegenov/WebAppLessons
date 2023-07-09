using Microsoft.AspNetCore.Mvc;
using WebAppLessonsApi.Application.Abstractions;
using WebAppLessonsApi.Application.Consumers;

namespace WebAppLessonsApi.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly IEvenPublisher _evenPublisher;

    public ApiController(IEvenPublisher evenPublisher)
    {
        _evenPublisher = evenPublisher;
    }

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
    {
        var @event = new UserCreatedEvent("Aslan", "Tyulegenov", 23);
        await _evenPublisher.Publish(@event, cancellationToken);

        return Ok(@event);
    }
}