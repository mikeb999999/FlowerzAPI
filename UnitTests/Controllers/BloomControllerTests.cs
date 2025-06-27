using FlowerzAPI.Controllers;
using Flowerz.DataContexts;
using Flowerz.EntityModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests;

public class BloomControllerTests
{
    public BloomControllerTests() { }

    [Fact]
    public void CanConstruct()
    {
        var services = new ServiceCollection();

        // Using In-Memory database for testing
        services.AddDbContext<FlowerzContext>(options =>
            options.UseInMemoryDatabase("TestDb"));

        var _serviceProvider = services.BuildServiceProvider();

        var context = _serviceProvider.GetService<FlowerzContext>();

        context?.Blooms.Add(
            new Bloom() { Id = 1, Name = "Meconopsis " + Guid.NewGuid().ToString(), Description = "Poppies e.g. blue, welsh" });
        context?.SaveChanges();

        var instance = new BloomController(context);

        Assert.NotNull(instance);
    }
}
