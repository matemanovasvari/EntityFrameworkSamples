namespace Kreta.Database.Entities;

[Table("Student")]
public class StudentEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long EducationalCode { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string MothersName { get; set; }

    public uint? AddressId { get; set; }
    public virtual AddressEntity Address { get; set; }

    public virtual ICollection<SubjectEntity> Subjects { get; set; }

    public virtual ICollection<GradeEntity> Grades { get; set; }
}
