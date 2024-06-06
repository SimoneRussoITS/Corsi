using System.Data;
using FirstApp.Models.Enums;
using FirstApp.Models.Services.Infrastructure;
using FirstApp.Models.ValueTypes;
using FirstApp.Models.ViewModels;

namespace FirstApp.Models.Services.Application;

public class AdoNetCourseService : ICourseService
{
    private readonly IDatabaseAccessor db;

    public AdoNetCourseService(IDatabaseAccessor db)
    {
        this.db = db;
    }
    public Task<List<CourseViewModel>> GetCoursesAsync()
    {
        string query = "SELECT * FROM courses";
        DataSet dataSet = db.Query(query);
        return null;
    }

    public Task<CourseDetailViewModel> GetCourseAsync(int id)
    {
        throw new NotImplementedException();
    }
}