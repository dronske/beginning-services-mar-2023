using LocationsApi.Models;
using LocationsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocationsApi.Controllers;

public class StatusController : ControllerBase
{
    private readonly UptimeClock _uptimeClock;

    public StatusController(UptimeClock uptimeClock)
    {
        _uptimeClock = uptimeClock;
    }

    [HttpGet("/support")]
    public async Task<ActionResult> GetStatus()
    {
        var sinceStartup = DateTime.Now - _uptimeClock.UpSince;
        var response = new GetStatusResponse()
        {
            ContactInfo = new ContactInfo()
            {
                Name = "Bob Smith",
                Email = "bob@aol.com",
                Phone = "555-1212"
            },
            Uptime = new Uptime()
            {
                Hours = sinceStartup.Hours,
                Minutes = sinceStartup.Minutes,
                Days = sinceStartup.Days,
                // Seconds = sinceStartup.Seconds,
                // Milliseconds = sinceStartup.Milliseconds
            }
        };
        return Ok(response);
    }
}
