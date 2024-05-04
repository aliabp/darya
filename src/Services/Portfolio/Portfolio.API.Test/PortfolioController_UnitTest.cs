using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Portfolio.API.Controllers;
using Portfolio.API.Models;
using Portfolio.API.Repositories;
using Portfolio.API.Services;

namespace Portfolio.API.Test;

public class PortfolioControllerUnitTest
{
    private readonly ILogger<PortfolioController> _logger;
    private readonly IWebHostEnvironment _environment;

    public PortfolioControllerUnitTest()
    {
        var mockLogger = new Mock<ILogger<PortfolioController>>();
        _logger = mockLogger.Object;
    }
    
    [Fact]
    public async Task UploadImage_ReturnsBadRequest_WhenFileIsNull()
    {
        // Arrange
        Mock<IPortfolioRepository> _mockRepo = new Mock<IPortfolioRepository>();
        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(service => service.SaveFileAsync(It.IsAny<string>(), It.IsAny<Stream>()))
            .Returns(Task.CompletedTask);
        var controller = new PortfolioController(_mockRepo.Object, _logger, _environment, mockFileService.Object);        
        var carouselItem = new CarouselItem()
        {
            Id = Guid.NewGuid().ToString(),
            Path = System.IO.Path.Combine("uploads", "file.jpg"),
            Image = null,
            Title = "Test Image",
            Caption = "This a test for uploading new carousel!",
            Order = 1
        };

        // Act
        var result = await controller.AddCarousel(carouselItem);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UploadImage_ReturnsOk_WhenFileIsNotNull()
    {
        // Arrange
        Mock<IPortfolioRepository> _mockRepo = new Mock<IPortfolioRepository>();
        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(service => service.SaveFileAsync(It.IsAny<string>(), It.IsAny<Stream>()))
            .Returns(Task.CompletedTask);
        var controller = new PortfolioController(_mockRepo.Object, _logger, _environment, mockFileService.Object);        
        var mockFile = new Mock<IFormFile>();
        const string content = "Hello World from a Fake File";
        var fileName = "test.jpg";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;
        mockFile.Setup(_ => _.FileName).Returns(fileName);
        mockFile.Setup(_ => _.Length).Returns(ms.Length);
        mockFile.Setup(m => m.OpenReadStream()).Returns(ms);
        mockFile.Setup(m => m.ContentDisposition).Returns(string.Format("inline; filename={0}", fileName));

        var carouselItem = new CarouselItem()
        {
            Id = Guid.NewGuid().ToString(),
            Path = System.IO.Path.Combine("uploads", "file.jpg"),
            Image = mockFile.Object,
            Title = "Test Image",
            Caption = "This a test for uploading new carousel!",
            Order = 1
        };

        // Act
        var result = await controller.AddCarousel(carouselItem);

        // Assert
        Assert.IsType<OkResult>(result);
    }
}