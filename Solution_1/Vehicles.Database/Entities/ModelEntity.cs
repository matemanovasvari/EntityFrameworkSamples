namespace Vehicles.Database.Entities;

[Table("Model")]
[Index(nameof(ModelName), IsUnique = true)]
public class ModelEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(20)]
    public string ModelName { get; set; }

    [Required]
    public uint IntrouctionYear { get; set; }

    [ForeignKey("Manufacturer")]
    public uint ManufacturerId { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }
}