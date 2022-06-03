using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class Toy
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        public string Color { get; set; }
        public string Condition { get; set; }
        public bool IsFavourite { get; set; }
    }
}