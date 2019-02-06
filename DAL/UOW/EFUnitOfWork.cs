using DAL.Entities;
using DAL.Repositories;

namespace DAL.UOW
{
    public class EFUnitOfWork : IUnitOFWork
    {
        private EFContext DB_Context;
        private EFGenericRepository<Student> StudentRepository;
        private EFGenericRepository<Teacher> TeacherRepository;
        private EFGenericRepository<Group> GroupRepository;
        private EFGenericRepository<Lesson> LessonRepository;
        private EFGenericRepository<ProblemStudent> ProblemStudentRepository;
        private EFGenericRepository<PresetStudent> PresetStudentRepository;
        private EFGenericRepository<ConcreteLesson> ConcreteLessonRepository;

        public EFUnitOfWork(string connectionString)
        {
            DB_Context = new EFContext(connectionString);
        }
        
       
        public IGenericRepository<Student> StudentUOW
        {
            get
            {
                if (StudentRepository == null)
                    StudentRepository = new EFGenericRepository<Student>(DB_Context);
                return StudentRepository;
            }
        }

        public IGenericRepository<Teacher> TeacherUOW
        {
            get
            {
                if (TeacherRepository == null)
                    TeacherRepository = new EFGenericRepository<Teacher>(DB_Context);
                return TeacherRepository;
            }
        }

        public IGenericRepository<Group> GroupUOW
        {
            get
            {
                if (GroupRepository == null)
                    GroupRepository = new EFGenericRepository<Group>(DB_Context);
                return GroupRepository;
            }
        }

        public IGenericRepository<Lesson> LessonUOW
        {
            get
            {
                if (LessonRepository == null)
                    LessonRepository = new EFGenericRepository<Lesson>(DB_Context);
                return LessonRepository;
            }
        }

        public IGenericRepository<ProblemStudent> ProblemStudentUOW
        {
            get
            {
                if (ProblemStudentRepository == null)
                    ProblemStudentRepository = new EFGenericRepository<ProblemStudent>(DB_Context);
                return ProblemStudentRepository;
            }
        }

        public IGenericRepository<PresetStudent> PresetStudentUOW
        {
            get
            {
                if (PresetStudentRepository == null)
                    PresetStudentRepository = new EFGenericRepository<PresetStudent>(DB_Context);
                return PresetStudentRepository;
            }
        }

        public IGenericRepository<ConcreteLesson> ConcreteLessonUOW
        {
            get
            {
                if (ConcreteLessonRepository == null)
                    ConcreteLessonRepository = new EFGenericRepository<ConcreteLesson>(DB_Context);
                return ConcreteLessonRepository;
            }
        }
        
        

        public void Save()
        {
             DB_Context.SaveChanges();
        }
    }
}
