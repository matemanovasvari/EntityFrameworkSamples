namespace Vehicles.Database.Entities;

[Table("Vehicle")] //tábla neve
[Index(nameof(LicencePlate), IsUnique = true)]

public class VehicleEntity
{
    [Key] //primary key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increment
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

    [ForeignKey("Color")]
    public uint ColorId { get; set; }
    public virtual ColorEntity Color { get; set; } //navigation property

    [ForeignKey("Model")]
    public uint ModelId { get; set; } 

    public virtual ModelEntity Model { get; set; }

    //[ForeignKey("FormOfUse")]
    public uint FormOfUseId { get; set; }

    public virtual FormOfUseEntity FormOfUse { get; set; }
}