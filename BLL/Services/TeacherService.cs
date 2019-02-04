using AutoMapper;
using BLL.Interfaces;
using BLL.TransferObjects;
using DAL.Entities;
using DAL.UOW;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    class TeacherService : ITeacherService, ILessonService
    {
        private readonly int maxTimeStudentCanSkippClasses = 5;
        private string NoteAboutStudent = "Не був присутній на занятті";

        EFUnitOfWork UnitOfWork { get; set; }

        public TeacherService(string connectionString)
        {
            UnitOfWork = new EFUnitOfWork(connectionString);
        }


        /// <summary>
        /// Add Student that is not on the lesson 
        /// </summary>
        /// <param name="_studentId">Student ID</param>        
        bool AddEmptyStudent(int? _studentId)
        {
            bool status;
            try
            {
                if (_studentId == null)
                    throw new ArgumentNullException();

                Student student = UnitOfWork.StudentUOW.Get(_studentId.Value); //Get student from DB

                if (student == null)                                            //Chack if studfent reference is not null, if he is realy in DB
                    throw new ArgumentNullException();


                IEnumerable<PresetStudent> presetStudents = UnitOfWork.PresetStudentUOW.GetAll();   //Get students that was not on lectures

                PresetStudent presetStudent = null;

                foreach (var item in presetStudents)
                {
                    if (item.StudentId == _studentId.Value)         //looking for if student with given ID is in the database
                        presetStudent = item;
                }

                if (presetStudent == null)
                    throw new NullReferenceException();

                if (presetStudent.CountOfSkippedClasses > maxTimeStudentCanSkippClasses)    //Looking if count of his skipped lessons is more then hecan skipp
                {
                    UnitOfWork.ProblemStudentUOW.Create(new ProblemStudent()                //if student skipp ore lesson than allowed, student adds to ProblemStudent Table 
                    {                                                                       //where Methodist can do somethig with him
                        Student = UnitOfWork.StudentUOW.Get(_studentId.Value),
                        Note = NoteAboutStudent
                    });
                }
                else
                {
                    presetStudent.CountOfSkippedClasses++;      //Add one more skiped class
                    UnitOfWork.StudentUOW.Update(student);                 //Update model                       
                }

                UnitOfWork.Save();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        
        /// <summary>
        /// Returns students by given group ID
        /// </summary>
        /// <param name="_groupId"></param>
        /// <returns></returns>
        public IEnumerable<StudentDTO> ShowStudentListBySelectedGroup(int? _groupId)
        {
            IEnumerable<Student> students = UnitOfWork.StudentUOW.GetAll();
            List<Student> selectedStudents = null;
            foreach (var item in students)
            {
                if (item.GroupId == _groupId)
                    selectedStudents.Add(item);
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(selectedStudents);
        }
        
        /// <summary>
        /// returns list of groups
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GroupDTO> GetGroups()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(UnitOfWork.GroupUOW.GetAll());
        }


        /// <summary>
        /// Create new Concrete Lesson thet takes them of lesson, date and teacher id
        /// </summary>
        /// <param name="them"></param>
        /// <param name="lessonDate"></param>
        /// <param name="teacher"></param>
        bool ILessonService.NewThemOfTheLesson(string them, DateTime lessonDate, int? teacherId)
        {
            bool status;
            try
            {
                Teacher teacher = UnitOfWork.TeacherUOW.Get(teacherId.Value);
                Lesson lesson = UnitOfWork.LessonUOW.Get(teacher.LessonId.Value);

                ConcreteLesson concretelesson = new ConcreteLesson()
                {
                    Description = them,
                    Lesson = lesson
                };

                UnitOfWork.ConcreteLessonUOW.Create(concretelesson);
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        /// <summary>
        /// create new instance of concrectLesson
        /// </summary>
        bool ILessonService.AddNewLesson(int? teacherId, string description)
        {
            bool state = false;
            try
            {
                Teacher _teacher = UnitOfWork.TeacherUOW.Get(teacherId.Value);
                _teacher.Lesson.ConcreteLesson.Add(new ConcreteLesson()
                {
                    Date = DateTime.Now,
                    teacher = _teacher,
                    Lesson = _teacher.Lesson,
                    LessonId = _teacher.Lesson.Id,
                    teacherId = _teacher.Id,
                    Description = description
                });
                UnitOfWork.Save();
                state = true;
            }
            catch (Exception)
            {
                state = false;
                throw;
            }
            return state;
        }
        
    }
}
