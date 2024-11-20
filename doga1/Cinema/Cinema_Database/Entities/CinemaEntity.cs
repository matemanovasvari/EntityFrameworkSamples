using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Database.Entities;

[Table("Cinema")]
public class CinemaEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [StringLength(25)]
    public string Name { get; set; }

    [ForeignKey("Address")]

    public uint AddressId { get; set; }
    public virtual AddressEntity Address { get; set; }

    public virtual ICollection<RoomEntity> Rooms { get; set; }
}
