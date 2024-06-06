using System;
using System.Collections.Generic;
using FirstApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Models.Services.Infrastructure;

public partial class MyCourseDbContext : DbContext
{
    public MyCourseDbContext(DbContextOptions<MyCourseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("courses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasColumnType("TEXT(100)")
                .HasColumnName("author");
            entity.Property(e => e.CourseDuration).HasColumnName("course_duration");
            entity.Property(e => e.Description)
                .HasColumnType("TEXT(10000)")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasColumnType("TEXT(100)")
                .HasColumnName("email");
            entity.Property(e => e.Price)
                .HasColumnType("NUMERIC")
                .HasColumnName("price");
            entity.Property(e => e.PriceCurrency)
                .HasDefaultValue("EUR")
                .HasColumnType("TEXT(3)")
                .HasColumnName("price_currency");
            entity.Property(e => e.Title)
                .HasColumnType("TEXT(100)")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("lessons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Description)
                .HasColumnType("TEXT(10000)")
                .HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("TEXT(8)")
                .HasColumnName("duration");
            entity.Property(e => e.Title)
                .HasColumnType("TEXT(100)")
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons).HasForeignKey(d => d.CourseId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
