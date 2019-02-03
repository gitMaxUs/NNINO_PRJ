using BL.Interfaces;
using BL.TransferObjects;
using BLL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UOW;
using AutoMapper;

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
            IEnumerable<Student> students = UnitOfWork.StudentsUOW.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(students);
        }

        public void CreateItem(StudentDTO instanceDTO)
        {
            if (instanceDTO == null)
                throw new ArgumentNullException();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, Student>()).CreateMapper();
            var student = mapper.Map<StudentDTO, Student>(instanceDTO);
            UnitOfWork.StudentsUOW.Create(student);
            UnitOfWork.Save();
        }

        public void DeleteItem(int? id)
        {
            var student = UnitOfWork.StudentsUOW.Get(id.Value);
            if (student != null)
            {
                UnitOfWork.StudentsUOW.Delete(id);
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

            UnitOfWork.StudentsUOW.Update(student);
            UnitOfWork.Save();
        }

        public StudentDTO GetItem(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Student student = UnitOfWork.StudentsUOW.Get(id.Value);

            if (student == null)
                throw new ArgumentNullException();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return (mapper.Map<Student, StudentDTO>(student));
        }



        public IEnumerable<StudentDTO> GetStudents(GroupDTO group)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeacherDTO> GetTeachers()
        {
            throw new NotImplementedException();
        }
    }
}
