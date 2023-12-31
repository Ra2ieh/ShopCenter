﻿namespace ShopCenter.Api.Controllers;
[ApiController]
[Route("api/v1/DelayReport/[action]")]
public class DelayReportController : Controller
{
    private readonly IMediator _mediator;
    public DelayReportController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Registeration([FromQuery]  int orderId)
    {
        var delayReportRegistrationCommandHandler = new DelayReportRegistrationCommand
        {
            OrderId = orderId,
        };
        var serviceResult = await _mediator.Send(delayReportRegistrationCommandHandler);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetRequest([FromQuery] int agentId)
    {
        var getDelayReportCommand = new GetDelayReportCommand
        {
            AgentId = agentId,
        };
        var serviceResult = await _mediator.Send(getDelayReportCommand);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDelayReport()
    {
        var getAllDelaysQuery = new GetAllDelaysQuery();
        var serviceResult = await _mediator.Send(getAllDelaysQuery);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }
}
