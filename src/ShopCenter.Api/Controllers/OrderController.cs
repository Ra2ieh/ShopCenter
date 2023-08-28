namespace ShopCenter.Api.Controllers;
[ApiController]
[Route("api/v1/Order/[action]")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddOrderCommand model)
    {

        var serviceResult = await _mediator.Send(model);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok();
    }
}
