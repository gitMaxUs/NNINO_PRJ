using AutoMapper;
using BL.TransferObjects;
using DAL.Entities;
using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class StudentService //: IStudentService
    {

        EFUnitOfWork unitOfWork { get; set; }
        public StudentService(string connectionString)
        {
            unitOfWork = new EFUnitOfWork(connectionString);
        }


        public async Task<IEnumerable<StudentDTO>> GetItemsAsync()
        {
            IEnumerable<Student> students = await unitOfWork.StudentsUOW.GetAll();
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, List<StudentDTO>>(students);
        }

        public void CreateItem(StudentDTO instanceDTO)
        {
            if (instanceDTO == null)
                throw new ArgumentNullException();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, Student>()).CreateMapper();
            var student = mapper.Map<StudentDTO, Student>(instanceDTO);
            unitOfWork.StudentsUOW.Create(student);
            unitOfWork.SaveAsync();
        }

        public void DeleteItem(int? id)
        {
            var game = unitOfWork.StudentsUOW.Get(id.Value);

            unitOfWork.StudentsUOW.Delete(id);
            unitOfWork.SaveAsync();
        }

        public void EditItem(StudentDTO instanceDTO)
        {
            if (instanceDTO == null)
                throw new ArgumentNullException();


            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, Student>()).CreateMapper();
            var student = mapper.Map<StudentDTO, Student>(instanceDTO);

            unitOfWork.StudentsUOW.Update(student);
            unitOfWork.SaveAsync();
        }

        public async Task<StudentDTO> GetItemAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Student student = await unitOfWork.StudentsUOW.Get(id.Value);

            if (student == null)
                throw new ArgumentNullException();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return (mapper.Map<Student, StudentDTO>(student));
        }


    }
}
