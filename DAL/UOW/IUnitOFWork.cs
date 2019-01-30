using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UOW
{
    public interface IUnitOFWork
    {
        IGenericRepository<Student> StudentsUOW { get; }

        IGenericRepository<Teacher> TeacersUOW { get; }

        IGenericRepository<Group> GroupUOW { get; }

        IGenericRepository<Lesson> LessonUOW { get; }

        void Save();
    }
}
