using Microsoft.EntityFrameworkCore;
using lms_server.Models;

namespace lms_server.database;

public class ApplicationDBContext : DbContext
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
}