using Microsoft.AspNetCore.Mvc;

namespace BloodDonor.API.Controllers;

[ApiController]
[Route("api/Donors")]
public class DonorsControllers : ControllerBase
{
    [HttpPost]
    public IActionResult CreateDonor(CreateDonorCommand command)
    {
        var Donor = await _mediator.Send(command);
        if (!DonorId.IsSucces)
        {
            return BadRequest(DonorId.Message);
        }

        return Ok(DonorId);
    }
}