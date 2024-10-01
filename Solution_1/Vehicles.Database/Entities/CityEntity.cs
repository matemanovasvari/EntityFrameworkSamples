
namespace Vehicles.Database.Entities;
[Table("City")]
public class CityEntity
{
    [Key]
    [Range(1000, 9999)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public uint PostalCode { get; set; }

    [StringLength(60)]
    [Required]
    public string Name { get; set; }

    public IReadOnlyCollection<StreetEntity> Streets { get; set; }
}