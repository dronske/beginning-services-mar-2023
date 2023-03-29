using Microsoft.AspNetCore.Mvc;

namespace LocationsApi.Controllers;

public class LocationsController : ControllerBase
{
    [HttpGet("/locations")]
    public async Task<ActionResult>  GetLocations()
    {
        return Ok();
    }
}
