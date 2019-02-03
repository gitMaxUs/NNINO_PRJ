using AutoMapper;
using BLL.TransferObjects;
using DAL.Entities;

namespace BL
{
    public class MapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<StudentDTO, Student>();
            cfg.CreateMap<Student, StudentDTO>();
            cfg.CreateMap<TeacherDTO, Teacher>();
            cfg.CreateMap<Teacher, TeacherDTO>();
            cfg.CreateMap<Lesson, LessonDTO>();
            cfg.CreateMap<LessonDTO, Lesson>();
        }
    }
}
