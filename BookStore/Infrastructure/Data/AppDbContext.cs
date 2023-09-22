using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var role = builder.Entity<IdentityRole>();
        role.HasData(new List<IdentityRole>()
        {
            new IdentityRole("admin") { NormalizedName = "admin".Normalize() },
            new IdentityRole("user") { NormalizedName = "user".Normalize() },
        });

        var user = builder.Entity<IdentityUser>();
        user.HasData(new List<IdentityUser>()
        {
            new IdentityUser()
            {
                //ConcurrencyStamp = Guid.NewGuid().ToString(),
                //SecurityStamp = Guid.NewGuid().ToString(),
                //Email = "sa@gmail.com",
                //NormalizedEmail = "sa@gmail.com".Normalize(),
                //UserName = "sa@gmail.com",
                //NormalizedUserName = "sa@gmail.com".Normalize(),

                //// пароль 12qw!@QW
                //PasswordHash = "AQAAAAIAAYagAAAAELxuVvmxYl35VhswIWLnoQzbPGb1ulKR/Rky0BZmCohJdVW3AEJ933ZlYVdy+Dkw7A==",
            }
        });
    }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
}
