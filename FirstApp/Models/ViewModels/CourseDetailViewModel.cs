using FirstApp.Models.Entities;
using FirstApp.Models.Enums;
using FirstApp.Models.ValueTypes;

namespace FirstApp.Models.ViewModels;

public class CourseDetailViewModel : CourseViewModel
{
    public string? Description { get; set; }
    public List<LessonViewModel> Lessons { get; set; }  
    public TimeSpan TotalCourseDuration => TimeSpan.FromSeconds(Lessons?.Sum(l => l.Duration.TotalSeconds) ?? 0);
    public static CourseDetailViewModel FromEntity(Course c)
    {
        return new CourseDetailViewModel
        {
            Author = c.Author,
            Description = c.Description,
            Duration = c.CourseDuration,
            Email = c.Email,
            Id = c.Id,
            Lessons = c.Lessons.Select(l => new LessonViewModel
            {
                CourseId = l.CourseId,
                Duration = l.Duration,
                Title = l.Title
            }).ToList(),
            Price = new Money(c.Price, Enum.Parse<Currency>(c.PriceCurrency, true))
        };
    }
}