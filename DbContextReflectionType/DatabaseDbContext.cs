using DbContextReflectionType.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;

namespace DbContextReflectionType
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions<DatabaseDbContext> options)
            : base(options)
        {
                
        }
        
        public DbSet<EntityOne> One { get; set; }
        public DbSet<EntityTwo> Two { get; set; }
    }
}