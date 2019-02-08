﻿using AutoMapper;
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
        StudentService StudentService;

        public HomeController()
        {
            StudentService = new StudentService(DBConnection.ConnectionString);     // connection string Deffault Connection
        }
        //IStudentService StudentService;
        //public HomeController(IStudentService serv)
        //{
        //    StudentService = serv;
        //    //  StudentService = new StudentService(DBConnection.ConnectionString);     // connection string Deffault Connection
        //}

        //[Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            //IEnumerable<StudentDTO> studentDTO;
            //try
            //{
            //    studentDTO = StudentService.GetItems();

            //    if (studentDTO == null)
            //        throw new Exception();

            //}
            //catch (ValidationException ex)
            //{
            //    ModelState.AddModelError(ex.Property, ex.Message);               
            //}
            IEnumerable<StudentDTO> studentDTO = StudentService.GetItems();

            if (studentDTO == null)
                throw new Exception(); 

            ViewBag.Title = "Home wewePage";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            var studentList = mapper.Map<IEnumerable<StudentDTO>, List<StudentViewModel>>(studentDTO);

            return View(studentList);
        }
    }
}
