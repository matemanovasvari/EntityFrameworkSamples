namespace Vehicles.Database.Entities;

[Table("Vehicle")]

public class VehicleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(7)]
    public string LicencePlate { get; set; }

    [Required]
    [StringLength(17)]
    public string ChassisNumber { get; set; }

    [Required]
    [StringLength(2)]
    public string EngineNumber { get; set; }

    [Required]
    [Range(2, 5)]
    public uint NumberOfDoors { get; set; }

    [Required]
    public uint Weight { get; set; }

    [Required]
    public uint Power { get; set; }
}