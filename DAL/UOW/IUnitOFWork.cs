using DAL.Entities;
using DAL.Repositories;

namespace DAL.UOW
{
    public interface IUnitOFWork
    { 
        IGenericRepository<Student> StudentUOW { get; }
        IGenericRepository<Teacher> TeacherUOW { get; }
        IGenericRepository<Group> GroupUOW { get; }
        IGenericRepository<Lesson> LessonUOW { get; }
        IGenericRepository<ProblemStudent> ProblemStudentUOW { get; }
        IGenericRepository<PresetStudent> PresetStudentUOW { get; }
        IGenericRepository<ConcreteLesson> ConcreteLessonUOW { get; }

        void Save();
    }
}
