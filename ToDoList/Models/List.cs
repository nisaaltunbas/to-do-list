using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class List
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        [Required]
        public string? Description { get; set; } 
    }
}
