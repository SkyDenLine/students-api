using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Students.Domain.Interfaces;
using Students.Infrastructure.Database;
using Students.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Students.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentContext>(opt => opt.UseInMemoryDatabase("StudentsDB"));
            services.AddControllers();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            InitializeDatabase(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void InitializeDatabase(IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<StudentContext>();
            context.Database.EnsureCreated();

            if (!context.Students.Any())
            {
                List<Student> testStudent = new List<Student>();

                for (int i = 1; i <= 100; i++)
                {
                    testStudent.Add(new Student { Id = i, Name = "Test name " + i, Groupe = "TestGroupe", Spec = "TestSpec" });
                }

                context.Students.AddRange(testStudent);
                context.SaveChanges();
            }
        }
    }
}
