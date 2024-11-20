using Cinema_Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Database;

public class ApplicationDBContext : DbContext
{
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CinemaEntity> Cinemas { get; set; }
    public DbSet<CityEntity> Cities { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<LanguageEntity> Languages { get; set; }
    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<ShowEntity> Shows { get; set; }

    public ApplicationDBContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CinemaDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressEntity>().HasOne(x => x.Cinema).WithOne(x => x.Address);
        modelBuilder.Entity<CinemaEntity>().HasOne(x => x.Address).WithOne(x => x.Cinema);

        modelBuilder.Entity<GenreEntity>().HasData(
            new GenreEntity{Id = 1, Name = "Comedy"},
            new GenreEntity{Id = 2, Name = "Romance"}
        );

        modelBuilder.Entity<LanguageEntity>().HasData(
            new LanguageEntity { Id = 1, Name = "Hungarian"},
            new LanguageEntity { Id = 2, Name = "English"}
        );
    }
}
