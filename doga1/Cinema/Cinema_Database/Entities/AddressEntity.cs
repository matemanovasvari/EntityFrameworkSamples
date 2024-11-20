using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Database.Entities;

[Table("Address")]
public class AddressEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [StringLength(25)]
    public string Street { get; set; }

    public uint HouseNumber { get; set; }

    public uint CityId { get; set; }
    public virtual CityEntity City { get; set; }

    [ForeignKey("Cinema")]
    public uint CinemaId { get; set; }
    public virtual CinemaEntity Cinema { get; set; }
}
