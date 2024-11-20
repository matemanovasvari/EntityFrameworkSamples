using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Database.Entities;

[Table("Show")]
public class ShowEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public DateTime Date { get; set; }

    public uint RoomId { get; set; }
    public RoomEntity Room {  get; set; }

    public uint MovieId { get; set; }
    public virtual MovieEntity Movie { get; set; }
}
