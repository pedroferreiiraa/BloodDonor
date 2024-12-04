using BloodDonor.Application.Commands.DonationCommands.CreateDonation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonor.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class DonationsControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationsControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateDonationCommand command)
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