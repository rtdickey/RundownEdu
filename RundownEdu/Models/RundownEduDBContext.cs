using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.Models
{
    public class RundownEduDBContext : DbContext
    {
        //public RundownEduDBContext()
        //{ }
        public RundownEduDBContext(DbContextOptions<RundownEduDBContext> options) : base(options)
        { }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Rundown> Rundowns { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Segment> Segments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=RundownEdu;Integrated Security=True");
        //    }
        //}
    }
}
