using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mis_mmc.Models;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var configuration = builder.Build();
        optionsBuilder.UseMySql(configuration
                ["ConnectionStrings:DefaultConnection"], new MySqlServerVersion(new Version(8, 0, 11)),
            options => options.EnableRetryOnFailure()
           
        );
    }
    public DbSet<CollegeDetails> CollegeDetails{ get; set; }
    public DbSet<FacultyModel> FacultyModels{ get; set; }
    public  DbSet<ProgramModel> ProgramModels { get; set; }
    public  DbSet<CourseModel> CourseModels { get; set; }
    
    public DbSet<LoginModel> LoginModels { get; set; }
    
    public DbSet<StudentModel> StudentModels { get; set; }
    
    public DbSet<TeacherModel> TeacherModels { get; set; }

    public DbSet<BookModel> BookModels { get; set; }
    public DbSet<BookIssueModel> BookIssueModels { get; set; }
    public DbSet<ExamModel> ExamModels { get; set; }
    public DbSet<ExamDetailsModel> ExamDetailsModels { get; set; }
    public DbSet<AssignmentModel> AssignmentModels { get; set; }
    public DbSet<LmsModel> LmsModels { get; set; }
    public DbSet<NtStaffsModel> NtStaffsModels { get; set; }
    public DbSet<AssignmentReturnModel> AssignmentReturnModels { get; set; }
}

