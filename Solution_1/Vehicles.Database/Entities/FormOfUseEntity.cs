namespace Vehicles.Database.Entities;

[Table("FormOfUse")]
[Index(nameof(Name), IsUnique = true)]

public class FormOfUseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    public IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }
}