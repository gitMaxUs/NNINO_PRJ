using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using BLL.TransferObjects;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WEB.Models;
using WEB.UTIL;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        IStudentService StudentService;
        MethodistService MethodistService;
        ITeacherService TeacherService;

        public HomeController()
        {
            StudentService = new StudentService(DBConnection.ConnectionString);     // connection string Deffault Connection
            MethodistService = new MethodistService(DBConnection.ConnectionString);
            TeacherService = new TeacherService(DBConnection.ConnectionString);

        }
        //IStudentService StudentService;
        //public HomeController(IStudentService serv)
        //{
        //    StudentService = serv;
        //    //  StudentService = new StudentService(DBConnection.ConnectionString);     // connection string Deffault Connection
        //}

        //[Authorize(Roles = "admin")]
        //public ActionResult Index()
        //{
        //    #region
        //    //IEnumerable<StudentDTO> studentDTO;
        //    //try
        //    //{
        //    //    studentDTO = StudentService.GetItems();

        //    //    if (studentDTO == null)
        //    //        throw new Exception();

        //    //}
        //    //catch (ValidationException ex)
        //    //{
        //    //    ModelState.AddModelError(ex.Property, ex.Message);               
        //    //}
        //    #endregion

        //    IEnumerable<StudentDTO> studentDTO = StudentService.GetItems();

        //    if (studentDTO == null)
        //        throw new Exception();

        //    ViewBag.Title = "Student view";

        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
        //    var studentList = mapper.Map<IEnumerable<StudentDTO>, List<StudentViewModel>>(studentDTO);

        //    return View(studentList);
        //}
        public ActionResult Index()
        {
            IEnumerable<StudentDTO> studentsDTO = StudentService.GetItems();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            var studentList = mapper.Map<IEnumerable<StudentDTO>, List<StudentViewModel>>(studentsDTO);


            //IEnumerable<PresetStudentDTO> presetStudentDTOs = TeacherService.
            IEnumerable<ProblemStudentDTO> problemStudentDTOs = MethodistService.GetStudentsWithProblems();

            foreach (var item in problemStudentDTOs)
            {
                var num = item.Student.Name;
            }


            return View(studentList);
        }
    }
}
