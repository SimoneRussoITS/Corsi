using FirstApp.Models.Entities;
using FirstApp.Models.Enums;
using FirstApp.Models.ValueTypes;

namespace FirstApp.Models.ViewModels;

public class CourseViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string? Duration { get; set; }
    public Money? Price { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }

    public static CourseViewModel FromEntity(Course c)
    {
        return new CourseViewModel
        {
            Id = c.Id,
            Title = c.Title,
            Author = c.Author,
            Description = c.Description,
            Email = c.Email,
            Price = new Money(c.Price, Enum.Parse<Currency>(c.PriceCurrency, true)),
            Duration = c.CourseDuration
        };
    }
}