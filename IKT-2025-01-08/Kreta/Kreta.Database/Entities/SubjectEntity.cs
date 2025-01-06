namespace Kreta.Database.Entities;

[Table("Subject")]
public class SubjectEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    public string SubjectName { get; set; }

    public ICollection<StudentEntity> Students { get; set; }

    public ICollection<GradeEntity> Grades { get; set; }
}