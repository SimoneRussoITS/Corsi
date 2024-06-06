using FirstApp.Models.ViewModels;

namespace FirstApp.Models.Services.Application;

public interface ICourseService
{
    Task<List<CourseViewModel>> GetCoursesAsync();
    Task<CourseDetailViewModel> GetCourseAsync(int id);
}