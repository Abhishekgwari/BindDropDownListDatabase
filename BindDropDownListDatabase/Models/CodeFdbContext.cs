using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BindDropDownListDatabase.Models;

public partial class CodeFdbContext : DbContext
{
    public CodeFdbContext()
    {
    }

    public CodeFdbContext(DbContextOptions<CodeFdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ABHISHEK_ASUS\\SQLEXPRESS;Database=CodeFDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentGender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Student Gender");
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Student Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
