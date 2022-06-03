using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Child
    {
        // public int Id { get; set; } Et forsøg på at få Display functionen til at virke med Blazor app, men det lykkedes ikke :(
       
        [Key]
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