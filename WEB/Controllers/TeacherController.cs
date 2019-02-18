using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using BLL.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using WEB.UTIL;
using WEB_NNINO_2.UTIL;

namespace WEB_NNINO_2.Controllers
{
    public class TeacherController : Controller
    {
        IStudentService StudentService;

        public TeacherController()
        {
            StudentService = new StudentService(DBConnection.ConnectionString);     // connection string Deffault Connection
        }
        // GET: Teacher
        public ActionResult Index()//(int? id)  
        {
            return View();
        }

        // GET: Teacher/Details/5
        [HttpPost]
        public ActionResult StudentList()//int id)
        {

            IEnumerable<StudentDTO> students = StudentService.GetItems();
            IEnumerable<StudentViewModel> studentsView = Mapper.Map<IEnumerable<StudentDTO>, IEnumerable<StudentViewModel>>(students);

            //var quest = from t in students
            //            where t..ToLower().StartsWith(findTests.ToLower())
            //            select t;


            return View(studentsView);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)//(string TestName, string question, List<string> Answers, List<int?> checkBoxNum)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
