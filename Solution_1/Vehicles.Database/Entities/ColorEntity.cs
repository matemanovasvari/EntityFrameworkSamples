namespace Vehicles.Database.Entities;

[Table("Color")]
[Index(nameof(Name), nameof(Code), IsUnique = true)]
public class ColorEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(32)]
    public string Name { get; set; }

    [Required]
    [StringLength(6)]
    public string Code { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }//navigation property
}
