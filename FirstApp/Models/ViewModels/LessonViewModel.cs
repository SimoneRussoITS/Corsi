
namespace FirstApp.Models.ViewModels;

public class LessonViewModel
{
    public int CourseId { get; set; }
    
    public string Title { get; set; }
    public TimeSpan Duration { get; set; }
}