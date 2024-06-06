using FirstApp.Models.Options;
using FirstApp.Models.Services.Infrastructure;
using FirstApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FirstApp.Models.Services.Application;

public class EfCourseService : ICourseService
{
    private readonly ILogger<EfCourseService> _logger;
    private readonly MyCourseDbContext _context;
    private readonly IOptionsMonitor<CoursesOptions> _coursesOptions;

    public EfCourseService(ILogger<EfCourseService> logger, MyCourseDbContext context, IOptionsMonitor<CoursesOptions> coursesOptions)
    {
        _logger = logger;
        _context = context;
        _coursesOptions = coursesOptions;
    }
    public async Task<List<CourseViewModel>> GetCoursesAsync()
    {
        var queryLinq = _context.Courses
            .AsNoTracking()
            .Select(c => CourseViewModel.FromEntity(c));
        var courses = await queryLinq.ToListAsync();
        return courses;
    }

    public async Task<CourseDetailViewModel> GetCourseAsync(int id)
    {
        _logger.LogInformation("Course {id} requested", id);
        
        var queryLinq = _context.Courses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .Where(c => c.Id == id)
            .Select(c => CourseDetailViewModel.FromEntity(c));
            var course = await queryLinq.SingleAsync();
        return course;
    }
}