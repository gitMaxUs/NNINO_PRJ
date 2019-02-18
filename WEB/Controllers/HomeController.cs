using AutoMapper;
using BL.Infrastructure;
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
        IMethodistService MethodistService;
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


            IEnumerable<StudentViewModel> swm;
           

            //IEnumerable<PresetStudentDTO> presetStudentDTOs = TeacherService.
            IEnumerable<ProblemStudentDTO> problemStudentDTOs = MethodistService.GetStudentsWithProblems();

            foreach (var item in problemStudentDTOs)
            {
                var num = item.Student.Name;
            }


            return View(studentList);
        }

        [HttpPost]
        public ActionResult Casy(IEnumerable<StudentViewModel> StudVM)
        {
            //try
            //{
            //    var list = StudentService.GetItems();
            //    var studId = 0;

            //    foreach (var item in list)
            //    {
            //        if (item.Surname == StudVM.Surname)
            //            studId = item.Id;
            //    }

            //    var studentDTO = new PresetStudentDTO
            //    {
            //        Date = DateTime.Now,
            //        Present = StudVM.IsPresent,
            //        StudentId = studId,
            //        StudentWasNotOnTheLesson = StudVM.IsPresent
            //    };
               
            //    return Content("<h2>Список відсутніх студентів відправлено на опрацювання</h2>");
            //}
            //catch (ValidationException ex)
            //{
            //    ModelState.AddModelError(ex.Property, ex.Message);
            //}

            return View(StudVM);
        }
    }
}
