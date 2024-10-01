namespace Vehicles.Database.Entities;
[Table("Street")]
public class StreetEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [StringLength(60)]
    public string Name { get; set; }
    [ForeignKey("City")]
    public uint CityId { get; set; }
    public virtual CityEntity City { get; set; }

    public IReadOnlyCollection<OwnerEntity> owners { get; set; }
}