using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Database.Entities;

[Table("Movie")]
public class MovieEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    public string Title { get; set; }

    public uint Playtime { get; set; }

    public DateTime StartOfShowing { get; set; }

    public DateTime EndOfShowing { get; set; }

    public string AgeRestriction { get; set; }

    public string Description { get; set; }

    public bool HasSubtitles { get; set; }

    public uint GenreId { get; set; }
    public virtual GenreEntity Genre { get; set; }

    public uint LanguageId { get; set; }
    public virtual LanguageEntity Language { get; set; }
}
