using AutoMapper;
using BL.Interfaces;
using BLL.TransferObjects;
using DAL.Entities;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class TeacherService //: ITeacherService
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
        /// <param name="_studentId"></param>        
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
        /// Create new Concrete Lesson thet takes them of lesson, date and teacher id
        /// </summary>
        /// <param name="them"></param>
        /// <param name="lessonDate"></param>
        /// <param name="teacher"></param>
        bool NewThemOfTheLesson(string them, DateTime lessonDate, int? teacherId)
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
        bool AddNewLesson(int? teacherId, string description)
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
