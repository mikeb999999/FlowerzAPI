using Microsoft.EntityFrameworkCore;
using Flowerz.DataContexts;
using Flowerz.Persistence.Entities;
using FlowerzAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddTransient<IBloomService, BloomService>();

//*** from Brave AI search (.net core ef 9 in memory example di in program.cs)
// Register the DbContext with the in-memory database
builder.Services.AddDbContext<FlowerzContext>(options =>
    options.UseInMemoryDatabase("InMemoryDatabase"));

//Register auto-mapper (needs AutoMapper extensions for Microsoft.Extensions.DependencyInjection....)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Seed data into the in-memory database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FlowerzContext>();
    // Seed data here
    context.Blooms.Add(new Bloom() { Id = 1, Name = "Meconopsis " + Guid.NewGuid().ToString(), Description = "Poppies e.g. blue, welsh" });
    context.Blooms.Add(new Bloom() { Id = 2, Name = "Antirrhinum " + Guid.NewGuid().ToString(), Description = "Snapdragons" });
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(endpoints => { _ = endpoints.MapControllers(); });


/////////////////
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
