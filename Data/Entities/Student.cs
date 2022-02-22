using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace D10.Data.Entites;

[Table("Student")]
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StudentId { get; set; }

    [Required, MaxLength(35)]
    public string? FirstName { get; set; }
    
    [Required, MaxLength(35)]
    public string? LastName { get; set; }

    [MaxLength(25)]
    public string? City { get; set; }

    public string? State { get; set; }
}
