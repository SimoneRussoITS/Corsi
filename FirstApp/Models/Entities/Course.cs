using System;
using System.Collections.Generic;

namespace FirstApp.Models.Entities;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Author { get; set; } = null!;

    public string? Email { get; set; }

    public int Price { get; set; }

    public string PriceCurrency { get; set; } = null!;

    public string CourseDuration { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
