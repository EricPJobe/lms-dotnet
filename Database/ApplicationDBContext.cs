using Microsoft.EntityFrameworkCore;
using lms_server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace lms_server.database;

public class ApplicationDBContext : IdentityDbContext<User>
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; } 
    public DbSet<Account> Account { get; set; }
    public DbSet<Profile> Profile { get; set; } 
    public DbSet<Asset> Asset { get; set; }
    public DbSet<Course> Course { get; set; } 
    public DbSet<Unit> Unit { get; set; }
    public DbSet<UnitCourse> UnitCourse { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<UserAccount> UserAccount { get; set; }
    public DbSet<AccountCourses> AccountCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "Instructor",
                    NormalizedName = "INSTRUCTOR"
                },
                new IdentityRole
                {
                    Name = "Inspector",
                    NormalizedName = "INSPECTOR"
                },
                new IdentityRole
                {
                    Name = "Special",
                    NormalizedName = "SPECIAL"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
    }

}