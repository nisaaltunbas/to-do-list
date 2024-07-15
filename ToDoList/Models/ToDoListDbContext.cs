using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListDbContext:DbContext
    {
        public DbSet<List> Lists { get; set; }

        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options):base(options)
        {
            
        }
    }
}
