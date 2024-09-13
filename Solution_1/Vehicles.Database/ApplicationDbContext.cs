
namespace Vehicles.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<VehicleEntity> Vehicles { get; set; }

    public ApplicationDbContext() : base()
    {
       
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VehicleDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
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

        builder.Entity<ManufacturerEntity>().HasData(new ManufacturerEntity
        {
            Id = 1,
            Name = "Honda"
        });

        builder.Entity<ManufacturerEntity>().HasData(new ManufacturerEntity
        {
            Id = 2,
            Name = "Lamborgini"
        });

        builder.Entity<ModelEntity>().HasData(new ModelEntity
        {
            Id = 1,
            ModelName = "Civic",
            IntrouctionYear = 1972,
        });
    }

}
