using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Hexagonality2.Domain.Entities;

public class StudentEntity
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is obligatory")]
    [NotNull()]
    [Length(minimumLength: 1, maximumLength: 50)]
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}