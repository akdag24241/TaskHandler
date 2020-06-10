using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class PracticeLandContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PracticeLand;Data Source=xxx");
        }
        public DbSet<TaskDefinition> TaskDefinitions { get; set; }

        public DbSet<TaskRunHistory> TaskRunHistories { get; set; }

    }
}
