namespace Vehicles.Database.Entities;

[Table("Manufacturer")]
[Index(nameof(Name), IsUnique = true)]
public class ManufacturerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(15)]
    public string Name { get; set; }


    public IReadOnlyCollection<ModelEntity> Models { get; set; }
}