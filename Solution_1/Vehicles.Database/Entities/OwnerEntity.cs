
namespace Vehicles.Database.Entities;
[Table("Owner")]
[Index(nameof(TAJ), IsUnique = true)]

public class OwnerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//autoincrement
    public uint Id { get; set; }

    [Required]
    [StringLength(60)]
    public string Name { get; set; }

    [Required]
    public DateTime Birthday { get; set; }

    [Required]
    [StringLength(20)]
    public string TAJ { get; set; }

    public IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }

    public uint StreetId { get; set; }

    public virtual StreetEntity Street { get; set; }
}