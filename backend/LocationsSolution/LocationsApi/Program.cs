using LocationsApi;
using LocationsApi.Adapters;
using LocationsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var onCallAddress = builder.Configuration.GetValue<string>("onCallAddress");
if(onCallAddress is null)
{
    throw new Exception("Can't start API without address");
}

builder.Services.AddHttpClient<OnCallDeveloperHttpAdapter>(client =>
{
    client.BaseAddress = new Uri(onCallAddress); // don't hardcode this
}).AddPolicyHandler(SrePolicies.GetDefaultRetryPolicyAsync())
.AddPolicyHandler(SrePolicies.GetDefaultCircuitBreaker());

var clock = new UptimeClock();
builder.Services.AddSingleton<UptimeClock>(clock);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
