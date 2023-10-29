using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SADIK;Initial Catalog=StudentAssistantDb;Integrated Security=True");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Daily> Dailies { get; set; }
        public DbSet<Feeling> Feelings { get; set; }
        public DbSet<LessonMessage> LessonMessages { get; set; }
        public DbSet<Notes> Notes { get; set; }
    }
}
