
namespace Vehicles.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }

    public DbSet<ModelEntity> Models { get; set; }
    public DbSet<VehicleEntity> Vehicles { get; set; }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<OwnerEntity> Owners { get; set; }
    public DbSet<StreetEntity> Streets { get; set; }
    public DbSet<CityEntity> Cities { get; set; }

    public DbSet<FormOfUseEntity> FormofUses { get; set; }
    public DbSet<TypeEntity> Types { get; set; }
    public ApplicationDbContext() : base()
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VehicleDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            //.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //UNIQUE constraint beallítása vagy osztály szinten vagy így
        //builder.Entity<VehicleEntity>()
        //       .HasIndex(x => x.LicencePlate)
        //       .IsUnique();   
        builder.Entity<ColorEntity>().HasData(new ColorEntity
        {
            Id = 1,
            Name = "white",
            Code = "ffffff"
        });

        builder.Entity<ColorEntity>().HasData(new ColorEntity
        {
            Id = 2,
            Name = "black",
            Code = "000000"
        });

        builder.Entity<FormOfUseEntity>().HasData(
            new FormOfUseEntity{ Id = 1, Name = "Taxi"},
            new FormOfUseEntity { Id = 2, Name = "Transport"}
        );

        builder.Entity<TypeEntity>().HasData(
            new TypeEntity{ Id = 1, Name = "Bus"},
            new TypeEntity { Id = 2, Name = "Truck"},
            new TypeEntity { Id = 3, Name = "Motorcycle"},
            new TypeEntity { Id = 4, Name = "Car" }
        );
    }
}