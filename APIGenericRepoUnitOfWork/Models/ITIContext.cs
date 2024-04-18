﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIGenericRepoUnitOfWork.Models;

public partial class ITIContext : DbContext
{
    public ITIContext()
    {
    }

    public ITIContext(DbContextOptions<ITIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Ins_Course> Ins_Courses { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Stud_Course> Stud_Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.Crs_Id).ValueGeneratedNever();

            entity.HasOne(d => d.Top).WithMany(p => p.Courses).HasConstraintName("FK_Course_Topic");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasOne(d => d.Dept_ManagerNavigation).WithMany(p => p.Departments).HasConstraintName("FK_Department_Instructor");
        });

        modelBuilder.Entity<Ins_Course>(entity =>
        {
            entity.HasOne(d => d.Crs).WithMany(p => p.Ins_Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ins_Course_Course");

            entity.HasOne(d => d.Ins).WithMany(p => p.Ins_Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ins_Course_Instructor");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.Property(e => e.Ins_Id).ValueGeneratedNever();

            entity.HasOne(d => d.Dept).WithMany(p => p.Instructors).HasConstraintName("FK_Instructor_Department");
        });

        modelBuilder.Entity<Stud_Course>(entity =>
        {
            entity.HasOne(d => d.Crs).WithMany(p => p.Stud_Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stud_Course_Course");

            entity.HasOne(d => d.St).WithMany(p => p.Stud_Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stud_Course_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.St_Lname).IsFixedLength();

            entity.HasOne(d => d.Dept).WithMany(p => p.Students).HasConstraintName("FK_Student_Department");

            entity.HasOne(d => d.St_superNavigation).WithMany(p => p.InverseSt_superNavigation).HasConstraintName("FK_Student_Student");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.Property(e => e.Top_Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}