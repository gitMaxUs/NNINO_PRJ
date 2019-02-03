using AutoMapper;
using BLL.TransferObjects;
using BLL.Interfaces;
using DAL.Entities;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class StudentService : IStudentService
    {

        EFUnitOfWork UnitOfWork { get; set; }
        public StudentService(string connectionString)
        {
            UnitOfWork = new EFUnitOfWork(connectionString);
        }
        //IUnitOFWork UnitOfWork { get; set; }
        //public StudentService(IUnitOFWork _UnitOfWork)
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
            var student =  UnitOfWork.StudentUOW.Get(id.Value);
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
            return  (mapper.Map<Student, StudentDTO>(student));
        }


    }
}
