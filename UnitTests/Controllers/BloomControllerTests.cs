using FlowerzAPI.Controllers;
using Flowerz.Models;
using FlowerzAPI.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UnitTests.Extensions;

namespace UnitTests;

public class BloomControllerTests
{
    public BloomControllerTests() { }

    [Fact]
    public void CanConstruct()
    {
        //    var services = new ServiceCollection();

        //    // Using In-Memory database for testing
        //    // Ref. https://medium.com/codenx/ef-core-in-memory-database-unit-testing-02d4658a9c78
        //    services.AddDbContext<FlowerzContext>(options =>
        //        options.UseInMemoryDatabase("TestDb"));

        //    var _serviceProvider = services.BuildServiceProvider();

        //    var context = _serviceProvider.GetService<FlowerzContext>();

        //    context?.Blooms.Add(
        //        new Bloom() { Id = 1, Name = "Meconopsis " + Guid.NewGuid().ToString(), Description = "Poppies e.g. blue, welsh" });
        //    context?.SaveChanges();

        var mockService = new Mock<IBloomService>();
        var instance = new BloomController(mockService.Object);

        Assert.NotNull(instance);
    }

    [Fact]
    public async Task GetShouldReturnBlooms()
    {
        // Arrange
        var mockService = new Mock<IBloomService>();
        var instance = new BloomController(mockService.Object);
        var blooms = new List<Bloom>();
        blooms.Add(new Bloom() { Id = 1, Name = "x", Description = "xxx" });
        blooms.Add(new Bloom() { Id = 2, Name = "y", Description = "xxy" });
        mockService.Setup(x => x.GetBlooms()).ReturnsAsync(blooms);
        //Act
        var result = await instance.GetBlooms();
        //Assert
        var okObjectResult = result as OkObjectResult;
        Assert.NotNull(okObjectResult);
        Assert.Equal((List<Bloom>)blooms, (List<Bloom>)okObjectResult.Value);
        mockService
            .Verify(x => x.GetBlooms(), Times.Once);
    }

    [Fact]
    public async Task Get1ShouldReturn1Bloom()
    {
        // Arrange
        var mockService = new Mock<IBloomService>();
        var instance = new BloomController(mockService.Object);
        var blooms = new List<Bloom>();
        blooms.Add(new Bloom() { Id = 1, Name = "x", Description = "xxx" });
        blooms.Add(new Bloom() { Id = 2, Name = "y", Description = "xxy" });
        mockService.Setup(x => x.GetBloom(1)).ReturnsAsync(blooms[0]);
        //Act
        var result = await instance.GetBloom(1);
        //Assert
        var okObjectResult = result as OkObjectResult;
        Assert.NotNull(okObjectResult);
        Assert.Equal(blooms[0], okObjectResult.Value);
        mockService
            .Verify(x => x.GetBloom(1), Times.Once);
        mockService
            .Verify(x => x.GetBloom(2), Times.Never);
    }

    [Fact]
    [Trait("Method", "CreateBloom")]
    public async Task CreateBloom_InternalError()
    {
        // Arrange
        var instance = new BloomController(null);
        var bloom0 = new Bloom() { Id = 0, Name = "x", Description = "xxx" };
        //Act
        var result = await instance.CreateBloom(bloom0);
        //Assert
        result.AssertError(HttpStatusCode.InternalServerError, "Object reference not set to an instance of an object.");
    }




    [Fact]
    [Trait("Method", "CreateBloom")]
    public async Task CreateBloom_OK()
    {
        // Arrange
        var mockService = new Mock<IBloomService>();
        var instance = new BloomController(mockService.Object);
        var blooms = new List<Bloom>();
        var bloom0 = new Bloom() { Id = 0, Name = "x", Description = "xxx" };
        mockService.Setup(x => x.CreateBloom(bloom0)).ReturnsAsync(bloom0);
        //Act
        var result = await instance.CreateBloom(bloom0);
        //Assert
        var okObjectResult = result as OkObjectResult;
        Assert.NotNull(okObjectResult);
        Assert.Equal(bloom0, okObjectResult.Value);
        mockService
            .Verify(x => x.CreateBloom(bloom0), Times.Once);
    }
}
