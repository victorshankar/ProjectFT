using Microsoft.EntityFrameworkCore;
using ProjectFT.Models;

namespace ProjectFT.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options) 
        {
            
        }

        public DbSet<TaskItem> TaskItems {  get; set; }
    }
}
