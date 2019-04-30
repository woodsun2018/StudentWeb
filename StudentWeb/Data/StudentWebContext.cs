using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentWeb.Models
{
    public class StudentWebContext : DbContext
    {
        public StudentWebContext (DbContextOptions<StudentWebContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolClass> SchoolClass { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

    }
}
