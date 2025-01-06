using Kreta.Database.Entities;

namespace Kreta.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<GradeEntity> Grades { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }


    public ApplicationDbContext() : base(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=KretaDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
    }
}
