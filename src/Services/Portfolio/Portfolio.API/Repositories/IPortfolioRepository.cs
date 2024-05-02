using Portfolio.API.Models;

namespace Portfolio.API.Repositories;

public interface IPortfolioRepository
{
    Task<IEnumerable<CarouselItem>> GetCarouselItems();
    Task<CarouselItem> GetCarouselItem(string id);
    Task CreateCarouselItem(CarouselItem carouselItem);
    Task<bool> UpdateCarouselItem(CarouselItem carouselItem);
    Task<bool> DeleteCarouselItem(string id);
}