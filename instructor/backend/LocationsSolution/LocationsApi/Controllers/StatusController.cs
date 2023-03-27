using LocationsApi.Models;
using LocationsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocationsApi.Controllers;

public class StatusController : ControllerBase
{
    private readonly UptimeClock _clock;

    public StatusController(UptimeClock clock)
    {
        _clock = clock;
    }


    // GET /status
    [HttpGet("/status")]
    public async Task<ActionResult> GetStatus()
    {
        var response = new GetStatusResponse()
        {
               ContactInfo = new ContactInfo()
               {
                   Name = "Bob Smith",
                   Email = "bob@aol.com",
                   Phone = "555-1212"
               },
               Uptime = new Uptime
               {
                   Hours = 23,
                   Minutes = 59,
                   Days = 2384,
               }
        };
        return Ok(response);
    }
}
