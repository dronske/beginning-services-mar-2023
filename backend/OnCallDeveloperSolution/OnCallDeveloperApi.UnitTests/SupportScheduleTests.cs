using Moq;
using OnCallDeveloperApi.Services;

namespace OnCallDeveloperApi.UnitTests;

public class SupportScheduleTests
{
    [Fact]
    public void NoInHouseSupportOnWeekends()
    {
        var stubbedSystemTime = new Mock<ISystemTime>();
        stubbedSystemTime.Setup(s => s.GetCurrent()).Returns(new DateTime(2023, 3, 25));
        var supportSchedule = new SupportSchedule(stubbedSystemTime.Object);
        Assert.False(supportSchedule.InternalSupportAvailable);
    }

    [Fact]
    public void InHouseSupportOnWeekdays()
    {
        var stubbedSystemTime = new Mock<ISystemTime>();
        stubbedSystemTime.Setup(s => s.GetCurrent()).Returns(new DateTime(2023, 3, 28));
        var supportSchedule = new SupportSchedule(stubbedSystemTime.Object);
        Assert.True(supportSchedule.InternalSupportAvailable);
    }
}
