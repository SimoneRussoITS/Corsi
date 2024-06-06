using FirstApp.Models.Services.Application;
using FirstApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers;

public class CoursesController : Controller
{
    private readonly ICourseService courseService;

    public CoursesController(ICourseService courseService)
    {
        this.courseService = courseService;
    }
    
    public async Task<IActionResult> Index()
    {
        List<CourseViewModel> courses = await courseService.GetCoursesAsync();
        return View(courses);
    }

    public async Task<IActionResult> Details(int id)
    {
        CourseDetailViewModel course = await courseService.GetCourseAsync(id);
        return View(course);
    }
}