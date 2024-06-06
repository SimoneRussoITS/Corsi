using FirstApp.Models.Enums;
using FirstApp.Models.ValueTypes;
using FirstApp.Models.ViewModels;

namespace FirstApp.Models.Services.Application;

public class CourseService : ICourseService
{
    public List<CourseViewModel> GetCourses()
    {
        var courseList = new List<CourseViewModel>();
        var rand = new Random();
        for (int i = 1; i <= 20; i++)
        {
            var price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
            var course = new CourseViewModel
            {
                Id = i,
                Title = $"Course {i}",
                Author = $"Author {i}",
                Duration = $"{rand.Next(1, 5)} years",
                Price = new Money(price, Currency.EUR)
            };
            courseList.Add(course);
        }
        return courseList;
    }

    public CourseDetailViewModel GetCourse(int id)
    {
        var rand = new Random();
        var price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
        var course = new CourseDetailViewModel
        {
            Id = id,
            Title = $"Course {id}",
            Author = "Nome Cognome",
            Duration = $"{rand.Next(1, 5)} years",
            Price = new Money(price, Currency.EUR),
            Description = $"Description of course {id}",
            Lessons = new List<LessonViewModel>()
        };
        for (var i = 1; i <= 5; i++)
        {
            var lesson = new LessonViewModel
            {
                Title = $"Lesson {i}",
                Duration = TimeSpan.FromSeconds(rand.Next(40, 90))
            };
            course.Lessons.Add(lesson);
        }
        return course;
    }
}