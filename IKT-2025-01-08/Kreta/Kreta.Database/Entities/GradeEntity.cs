namespace Kreta.Database.Entities;

[Table("Grade")]
public class GradeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public uint Value { get; set; } //1-5

    public uint SubjectId { get; set; }
    public virtual SubjectEntity Subject { get; set; }

    public long StudentEducationalCode { get; set; }
    public virtual StudentEntity Student { get; set; }
}