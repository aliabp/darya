using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Repositories;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PortfolioController(IPortfolioRepository portfolioRepository, ILogger<PortfolioController> logger)
    : ControllerBase
{
    private readonly IPortfolioRepository _portfolioRepository = portfolioRepository ?? throw new ArgumentNullException(nameof(portfolioRepository));
    private readonly ILogger<PortfolioController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
}