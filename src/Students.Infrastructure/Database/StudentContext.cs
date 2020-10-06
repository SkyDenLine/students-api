using Microsoft.EntityFrameworkCore;
using Students.Domain.Models;

namespace Students.Infrastructure.Database
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

       public DbSet<Student> Students { get; set; }
    }
}
