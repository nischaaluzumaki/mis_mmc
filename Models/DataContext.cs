using Microsoft.EntityFrameworkCore;

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

}
