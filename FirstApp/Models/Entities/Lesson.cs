﻿using System;
using System.Collections.Generic;

namespace FirstApp.Models.Entities;

public partial class Lesson
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public TimeSpan Duration { get; set; }

    public virtual Course Course { get; set; } = null!;
}
