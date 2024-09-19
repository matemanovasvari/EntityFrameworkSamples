using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Database.Entities;

[Table("FormOfUse")]
[Index(nameof(Name), IsUnique = true)]

public class FormOfUseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }
}
