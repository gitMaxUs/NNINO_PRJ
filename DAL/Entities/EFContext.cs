using System.Data.Entity;

namespace DAL.Entities
{
    public class EFContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PresetStudent> PresetStudents { get; set; }

        public EFContext() : base("DiplomDB")
        {

        }
        public EFContext(string connectionString)
            : base(connectionString)
        { }

    }
    //class EFContextInitializer : DropCreateDatabaseIfModelChanges<EFContext>
    //{
    //    protected override void Seed(EFContext db)
    //    {
    //        Teacher teacher;
    //        Lesson lesson;
    //        Student student1 = new Student();
    //        Student student2;

    //        student1.Group.GroupName = "salsa";

    //        lesson = new Lesson()
    //        {
    //            LessonName = "Math"
    //            //  ThemsOfLesson = new ConcreteLesson();
    //        };
    //        teacher = new Teacher()
    //        {
    //            Name = "Anton",
    //            Surname = "Dzuba",
    //            Lesson = lesson
    //        };
    //        Group group = new Group()
    //        {
    //            GroupName = "428",
    //            //  Students = Students.A
    //        };
    //        student1 = new Student
    //        {
    //            Adress = "Lviv",
    //            BirthDate = "",
    //            Name = "Oleg",
    //            Surname = "Danevich",
    //            PhoneNumber = "324234324",
    //            PerentPhoneNumber = "123242"
    //        };

    //        student2 = new Student
    //        {
    //            Adress = "Kuev",
    //            BirthDate = "",
    //            Name = "Anton",
    //            Surname = "Don",
    //            PhoneNumber = "030494932",
    //            PerentPhoneNumber = "23244242"
    //        };

    //        db.Students.Add(student1);
    //        db.Students.Add(student2);
    //        db.Teachers.Add(teacher);
    //        db.Lessons.Add(lesson);
    //        db.Groups.Add(group);
    //        db.SaveChanges();
    //    }
    //}

}
