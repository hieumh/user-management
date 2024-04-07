using Microsoft.EntityFrameworkCore;
using UserManagement.Domains.Models;

namespace UserManagement.Infrastructures.Repositories
{
    public class RepositoryContext(DbContextOptions<RepositoryContext> options) : DbContext(options)
    {
        public DbSet<User>? Users { get; set; }
    }
}