using Alba;
using OnCallDeveloperApi;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnCallDeveloperApi.Models;

namespace OnCallDeveloperApi.AcceptanceTests;

public class GettingOnCallDeveloper
{
    [Fact]
    public async Task CanGetOnCallDeveloperDuringWeekdays()
    {
        await using var host = await AlbaHost.For<Program>();
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();
        });
        var expected = new OnCallDeveloperModel
        {
            Name = "Bob Smith",
            Phone = "888-8888",
            Email = "bob@company.com"
        };
        var actualResponse = response.ReadAsJson<OnCallDeveloperModel>();
        Assert.Equal(expected, actualResponse);
    }

    [Fact]
    public async Task CanGetOnCallDeveloperDuringWeekends()
    {
        await using var host = await AlbaHost.For<Program>();
        var response = await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();
        });
        var expected = new OnCallDeveloperModel
        {
            Name = "House of Outsourced Support, Inc.",
            Phone = "800 111-1111",
            Email = "support@house-of-outsourced-support.com"
        };
        var actualResponse = response.ReadAsJson<OnCallDeveloperModel>();
        Assert.Equal(expected, actualResponse);
    }
}
