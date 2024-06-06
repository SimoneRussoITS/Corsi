using FirstApp.Models.Options;
using FirstApp.Models.Services.Application;
using FirstApp.Models.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddScoped<ICourseService, AdoNetCourseService>();
builder.Services.AddScoped<ICourseService, EfCourseService>();
builder.Services.AddScoped<IDatabaseAccessor, SqliteDatabaseAccessor>();

builder.Services.AddDbContextPool<MyCourseDbContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
    optionsBuilder.UseSqlite(connectionString);
});

//Options
builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<CoursesOptions>(builder.Configuration.GetSection("Courses"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
