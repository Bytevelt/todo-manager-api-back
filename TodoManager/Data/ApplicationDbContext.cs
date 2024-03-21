using TodoManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace TodoManager.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<NewTask> Tasks { get; set; }
    }
}
