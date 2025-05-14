using Microsoft.EntityFrameworkCore;
using lms_server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace lms_server.database;

public class ApplicationDBContext : IdentityDbContext<AppUser>
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    // public DbSet<User> User { get; set; }
    // public DbSet<Role> Role { get; set; } 
    public DbSet<Account> Account { get; set; }
    public DbSet<Profile> Profile { get; set; } 
    public DbSet<Asset> Asset { get; set; }
    public DbSet<Course> Course { get; set; } 
    public DbSet<Unit> Unit { get; set; }
    public DbSet<ParsedWord> ParsedWord { get; set; }
    public DbSet<UnitCourse> UnitCourse { get; set; }
    // public DbSet<UserRole> UserRole { get; set; }
    // public DbSet<UserAccount> UserAccount { get; set; }
    public DbSet<AccountCourses> AccountCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Profile>(x => x.HasKey(p => new { p.AppUserId }));
        builder.Entity<Profile>()
            .HasOne(u => u.AppUser)
            .WithOne(p => p.Profile)
            .HasForeignKey<Profile>(p => p.AppUserId);

        builder.Entity<Account>(x => x.HasKey(p => new { p.AppUserId }));
        builder.Entity<Account>()
            .HasOne(u => u.AppUser)
            .WithOne(p => p.Account)
            .HasForeignKey<Account>(p => p.AppUserId);

        
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "3",
                Name = "Instructor",
                NormalizedName = "INSTRUCTOR"
            },
            new IdentityRole
            {   
                Id = "4",    
                Name = "Inspector",
                NormalizedName = "INSPECTOR"
            },
            new IdentityRole
            {
                Id = "5",
                Name = "Special",
                NormalizedName = "SPECIAL"
            }
        );
    }

}