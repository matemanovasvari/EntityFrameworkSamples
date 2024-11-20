namespace Vehicles.Database.Entities;

[Table("Type")]
[Index(nameof(Name), IsUnique = true)]
public class TypeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }
}