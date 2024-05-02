using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Models;

public class CarouselItem
{
    [Key]
    public string Id = new Guid().ToString();
    public string Path { set; get; } = @"../../../../uploads/carousel/default.png";
    public string Title { set; get; } = "No title";
    public string Caption { set; get; } = "Caption not found!";
    public int Order { set; get; } = 1;
}