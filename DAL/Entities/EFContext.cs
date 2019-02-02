using System.Data.Entity;

namespace DAL.Entities
{
    public class EFContext : DbContext
    {
        public EFContext(string connectionString)
              : base(connectionString)
        { }

        public EFContext() 
            : base("DefaultConnection")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PresetStudent> PresetStudents { get; set; }

    }

}
