using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class Child
    {
        [Key]
        //public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [Range(3, 6)]
        public int Age { get; set; }
        
        [Required]
        public string Gender { get; set; }
    }
}