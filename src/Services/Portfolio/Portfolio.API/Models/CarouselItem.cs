using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.API.Models;

public class CarouselItem
{
    [Key] 
    public string Id { set; get; } = Guid.NewGuid().ToString();
    public string Path { set; get; } = @"../../../../uploads/carousel/default.png";
    [NotMapped]
    public IFormFile Image { set; get; }
    public string Title { set; get; } = "No title";
    public string Caption { set; get; } = "Caption not found!";
    public int Order { set; get; } = 1;
}