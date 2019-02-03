using AutoMapper;
using BL.Interfaces;
using BLL.Interfaces;
using BLL.TransferObjects;
using DAL.Entities;
using DAL.UOW;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    class MethodistService : IMethodistService, IGenericService<StudentDTO>
    {
        IUnitOFWork UnitOfWork { get; set; }
        public MethodistService(string connectionString)
        {
            UnitOfWork = new EFUnitOfWork(connectionString);
        }

        //IUnitOFWork UnitOfWork { get; set; }
        //public MethodistService(IUnitOFWork _UnitOfWork)
        //{
        //    UnitOfWork = _UnitOfWork;
        //}


        public IEnumerable<StudentDTO> GetItems()
        {
            IEnumerable<Student> students = UnitOfWork.StudentUOW.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(students);
        }

        public void CreateItem(StudentDTO instanceDTO)
        {
            if (instanceDTO == null)
                throw new ArgumentNullException();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, Student>()).CreateMapper();
            var student = mapper.Map<StudentDTO, Student>(instanceDTO);
            UnitOfWork.StudentUOW.Create(student);
            UnitOfWork.Save();
        }

        public void DeleteItem(int? id)
        {
            var student = UnitOfWork.StudentUOW.Get(id.Value);
            if (student != null)
            {
                UnitOfWork.StudentUOW.Delete(id);
                UnitOfWork.Save();
            }
            else throw new Exception();
        }

        public void EditItem(StudentDTO instanceDTO)
        {
            if (instanceDTO == null)
                throw new ArgumentNullException();


            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, Student>()).CreateMapper();
            var student = mapper.Map<StudentDTO, Student>(instanceDTO);

            UnitOfWork.StudentUOW.Update(student);
            UnitOfWork.Save();
        }

        public StudentDTO GetItem(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Student student = UnitOfWork.StudentUOW.Get(id.Value);

            if (student == null)
                throw new ArgumentNullException();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return (mapper.Map<Student, StudentDTO>(student));
        }

    
        public IEnumerable<StudentDTO> GetStudents(GroupDTO group)
        {
            IEnumerable<Student> students = UnitOfWork.StudentUOW.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(students);
        }


        /// <summary>
        /// Returns List of Teachers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TeacherDTO> GetTeachers()
        {
            IEnumerable<Teacher> teachers = UnitOfWork.TeacherUOW.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Teacher, TeacherDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Teacher>, List<TeacherDTO>>(teachers);
        }

        /// <summary>
        /// Returns students that have lots of skipped lessons
        /// </summary>
        /// <returns></returns>a
        public IEnumerable<ProblemStudentDTO> GetStudentsWithProblems()
        {
            IEnumerable<Student> students = UnitOfWork.StudentUOW.GetAll();
            IEnumerable<ProblemStudent> problemStudents = UnitOfWork.ProblemStudentUOW.GetAll();
             
           
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProblemStudent, ProblemStudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ProblemStudent>, IEnumerable<ProblemStudentDTO>>(problemStudents);
 
        }
    }
}
