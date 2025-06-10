using Flowerz.DataContext.InMem;
using Flowerz.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
//builder.Services.AddFlowerzContext(); // in FlowerzContextExtensions !

//builder.Services.AddDbContext<FlowerzContext>(options =>
//    options.UseInMemoryDatabase("InMemoryDb"));

var options = new DbContextOptionsBuilder()
    .UseInMemoryDatabase(databaseName: "Test")
.Options;

using (var context = new FlowerzContext(options))
{
    var bloom = new Bloom { Name = "flower1" };
    context.Blooms.Add(bloom);
    context.SaveChanges();
}
// .
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//////////////// foll. not in weather forecast app code ////////////////
//Register the services
//this.RegisterDependencies(services);

//Configure controllers and views
//builder.Services.AddControllersWithViews()
//    .AddViewLocalization()
//    .AddDataAnnotationsLocalization();
builder.Services.AddControllers();
///////////////////////////////////////////////////////////////////////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    /////////////////
    app.UseDeveloperExceptionPage();
    /////////////////
}

app.UseHttpsRedirection();

/////////////////
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
