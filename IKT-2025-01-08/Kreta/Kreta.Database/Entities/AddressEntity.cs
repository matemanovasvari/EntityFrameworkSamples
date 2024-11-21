namespace Kreta.Database.Entities;

[Table("Address")]
public class AddressEntity
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string CountryName { get; set; }

    [Required]
    public string CityName { get; set; }

    [Required] 
    public string PostalCode { get; set; }

    [Required]
    public string StreetName { get; set; }

    [Required]
    public string HouseNumber { get; set; }

    public ICollection<StudentEntity> Students { get; set; }
}