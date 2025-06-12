using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Flowerz.EntityModels;

[Table("Bloom")]
public partial class Bloom
{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set; } = 0;

    [Required]
    [JsonPropertyName("Name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [JsonPropertyName("Description")]
    [StringLength(100)]
    public string Description { get; set; } = null!;
}
