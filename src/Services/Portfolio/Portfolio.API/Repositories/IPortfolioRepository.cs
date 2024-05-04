using Portfolio.API.Models;

namespace Portfolio.API.Repositories;

public interface IPortfolioRepository
{
    Task<IEnumerable<CarouselItem>> GetCarouselItems();
    Task CreateCarouselItem(CarouselItem carouselItem);
    Task<bool> DeleteCarouselItem(string id);
}