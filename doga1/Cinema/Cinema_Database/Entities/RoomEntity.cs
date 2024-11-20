using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Database.Entities;

[Table("Room")]
public class RoomEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [StringLength(25)]
    public string Name { get; set; }

    public uint CinemaId {  get; set; }
    public virtual CinemaEntity Cinema { get; set; }

    public virtual ICollection<ShowEntity> Shows { get; set; }
}
