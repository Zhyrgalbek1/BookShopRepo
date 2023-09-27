using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<Basket> Baskets => Set<Basket>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasIndex(b => b.Title)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
        modelBuilder.Entity<User>().Navigation(u => u.Basket).AutoInclude();
        modelBuilder.Entity<User>().Navigation(u => u.Profile).AutoInclude();
        modelBuilder.Entity<Basket>().Navigation(b => b.Books).AutoInclude();

        var userProfile = modelBuilder.Entity<UserProfile>();
        userProfile.ToTable("UserProfiles");
        userProfile.HasKey(up => up.UserId);

        var user = modelBuilder.Entity<User>();
        user.HasIndex(c => c.Username).IsUnique();
    }
}
