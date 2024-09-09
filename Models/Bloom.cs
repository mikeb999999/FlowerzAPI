using System.ComponentModel.DataAnnotations;

namespace FlowerzAPI.Models
{
    public record Bloom(
        int Id,

        [Required]
        [StringLength(100)]
        string Name,

        [StringLength(100)]
        string? Description);
}
