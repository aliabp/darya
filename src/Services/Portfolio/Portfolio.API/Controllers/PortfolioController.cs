using System.Net;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Models;
using Portfolio.API.Repositories;
using Portfolio.API.Services;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PortfolioController(IPortfolioRepository portfolioRepository, 
    ILogger<PortfolioController> logger, IWebHostEnvironment environment, IFileService fileService) : ControllerBase
{
    private readonly IWebHostEnvironment _environment = environment;
    private readonly IFileService _fileService = fileService;
    private readonly IPortfolioRepository _portfolioRepository = 
        portfolioRepository ?? throw new ArgumentNullException(nameof(portfolioRepository));
    private readonly ILogger<PortfolioController> _logger = 
        logger ?? throw new ArgumentNullException(nameof(logger));

    [HttpGet(Name = "GetCarouselItems")]
    [ProducesResponseType(typeof(IEnumerable<CarouselItem>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult<IEnumerable<CarouselItem>>> GetCarouselItems()
    {
        try
        {
            // retrive all carousel items from database
            var carouselItems = await _portfolioRepository.GetCarouselItems();
            if (!carouselItems.Any())
            {
                _logger.LogWarning("No carousel item found!");
                return NoContent();
            }
            return Ok(carouselItems);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetCarouselItems action: {ex.Message}");
            //return StatusCode(500, "Internal server error");
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost(Name = "AddCarousel")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddCarousel([FromForm] CarouselItem carouselItem)
    {
        // check if Image file is empty
        if (carouselItem.Image == null || carouselItem.Image.Length == 0)
        {
            return BadRequest("An image file is required.");
        }

        // check modelstate validity
        if (!ModelState.IsValid)
        {
            return BadRequest("Somthing is wrong.");
        }
        
        // check image extention is acceptable
        var allowedExtensions = new[] { ".jpg", ".png" };
        var extension = Path.GetExtension(carouselItem.Image.FileName).ToLowerInvariant();

        if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
        {
            return BadRequest("Invalid file type. Only jpg and png are allowed.");
        }
        
        // check image size do not exceed
        if (carouselItem.Image.Length > 10000000)
        {
            return BadRequest("The file size exceeds the limit.");
        }
        
        try
        {
            // set path to save image on server
            var filePath = Path.Combine("uploads", carouselItem.Image.FileName);
            //var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            //Directory.CreateDirectory(filePath);

            //var filePath = Path.Combine(uploadsFolder, $"{carouselItem.Image.FileName}");
            
            // upload image on server
            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
                //await carouselItem.Image.CopyToAsync(stream);
            //}
            
            await _fileService.SaveFileAsync(filePath, carouselItem.Image.OpenReadStream());
            
            // add new carousel item to database
            await _portfolioRepository.CreateCarouselItem(carouselItem);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside AddCarousel action: {ex.Message}");
            //return StatusCode(500, "Internal server error");
            return StatusCode(500, ex.Message);
        }
    }
}