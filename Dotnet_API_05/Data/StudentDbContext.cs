using Dotnet_API_05.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_05.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students =>Set<Student>();
    }
}
