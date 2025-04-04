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

    // It might be better to make it a class, since record is immutable
    //public class Bloom {
    //    public int Id { get; set; }

    //    [Required]
    //    [StringLength(100)]
    //    public string? Name { get; set; }

    //    [StringLength(100)]
    //   public  string? Description { get; set; }
    //}
}
