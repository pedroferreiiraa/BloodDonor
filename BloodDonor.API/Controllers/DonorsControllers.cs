using BloodDonor.Application.Commands.CreateDonorCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonor.API.Controllers;

[ApiController]
[Route("api/donors")]
public class DonorsControllers : ControllerBase
{
    
    
    private readonly IMediator _mediator;

    public DonorsControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateDonor(CreateDonorCommand command)
    {
        var DonorId = await _mediator.Send(command);
        if (!DonorId.IsSuccess)
        {
            return BadRequest(DonorId.Message);
        }
        return Ok(DonorId);
    }
}