using BloodDonor.Application.Commands.AddressCommands.CreateAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonor.API.Controllers;

[Route("api/address")]
[ApiController]
public class AddressControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateAddressCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return CreatedAtAction(nameof(GetDonationById), new { id = result.Data }, command);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDonationById(int id)
    {
        // var query = new GetDonationByIdQuery(id);
        //
        // var result = await _mediator.Send(query);
        //
        // if (!result.IsSuccess)
        //     return BadRequest(result.Message);

        return Ok();
    }
    
    
}