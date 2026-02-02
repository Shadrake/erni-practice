using System.ComponentModel.DataAnnotations;

namespace Practice.Api.Entities;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty; // Para evitar null
    public string? Description { get; set; } // Opcional
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; } // opcional
    public TaskStatus Status { get; set; }
}
