using Portfolio.API.Models;

namespace Portfolio.API.Repositories;

public class PortfolioRepository : IPortfolioRepository
{
    public async Task<IEnumerable<CarouselItem>> GetCarouselItems()
    {
        throw new NotImplementedException();
    }

    public async Task<CarouselItem> GetCarouselItem(string id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateCarouselItem(CarouselItem carouselItem)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCarouselItem(CarouselItem carouselItem)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCarouselItem(string id)
    {
        throw new NotImplementedException();
    }
}