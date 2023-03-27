using LocationsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// this wouldd have in "ConfigureServices" in your Startup.cs
// Add services to the container.
// all the behind the scenes stuff that makes up our application

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var clock = new UptimeClock();
builder.Services.AddSingleton<UptimeClock>(clock);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin(); // Promiscuous 
        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();
// This would have been in the Configure method in startup
// the thing that will actually handle incoming requests.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
// Create the "Route Table" - phone book.
// GET /status -> StatusController -> GetStatus


app.Run(); // Blocking - where the "kestrel web server starts listening"
