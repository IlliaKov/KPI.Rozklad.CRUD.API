using Microsoft.EntityFrameworkCore;
using Rozklad.CRUD.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.DAL.Repositories
{
    public class RozkladContext: DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserClass> UserClasses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        public RozkladContext(DbContextOptions<RozkladContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
