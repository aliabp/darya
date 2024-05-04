using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.API.Models;

namespace Portfolio.API.Repositories;

public class PortfolioRepository(AppDbContext dbContext, ILogger<PortfolioRepository> logger)
    : IPortfolioRepository
{
    private readonly AppDbContext _carouselItemContext = 
        dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly ILogger<PortfolioRepository> _logger = 
        logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<IEnumerable<CarouselItem>> GetCarouselItems()
    {
        var carouselItems = new List<CarouselItem>();
        
        try
        {
            // get all carousel items from database using db context
            carouselItems = await _carouselItemContext.CarouselItems.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetCarouselItems method in PortfolioRepository: {ex.Message}");
            carouselItems = new List<CarouselItem>();
        }

        return carouselItems;
    }

    public async Task CreateCarouselItem(CarouselItem carouselItem)
    {
        try
        {
            // add new carousel item to database using db context
            await _carouselItemContext.CarouselItems.AddAsync(carouselItem);
            await _carouselItemContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside CreateCarouselItem method in PortfolioRepository: {ex.Message}");
        }
    }

    public async Task<bool> DeleteCarouselItem(string id)
    {
        var carouselItem = await _carouselItemContext.CarouselItems.FirstOrDefaultAsync(c => c.Id == id);

        if (carouselItem == null)
        {
            _logger.LogWarning("Carousel Item not found to delete.");
            return false;
        }
            
        try
        {
            // delete carousel item with requested id from database using db context
            _carouselItemContext.CarouselItems.Remove(carouselItem);
            await _carouselItemContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside DeleteCarouselItem method in PortfolioRepository: {ex.Message}");
            return false;
        }
        
    }
}