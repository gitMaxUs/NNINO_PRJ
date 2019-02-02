using AutoMapper;
using BL.Services;
using BL.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WEB.Models;
using WEB.UTIL;

namespace WEB_NNINO_2.Controllers
{
    public class MethodistController : ApiController
    {
        StudentService StudentService;

        public MethodistController()
        {
            StudentService = new StudentService(DBConnection.ConnectionString);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetListOfStudents()
        {
            IEnumerable<StudentDTO> studentDTO = await StudentService.GetItemsAsync();

            if (studentDTO == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            return Ok(studentDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetStudentById(int? id)
        {
            if (id == null)
                return NotFound();

            StudentDTO studentDTO = await StudentService.GetItemAsync(id);
            if (studentDTO == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            StudentViewModel studentView = mapper.Map<StudentDTO, StudentViewModel>(studentDTO);

            //  StudentService.CreateItem(await StudentService.GetItemAsync(id));

            return Ok(studentView);
        }

        // POST: api/Student
        //[HttpPost("upload")]
        [HttpPost]
        public IHttpActionResult CreateNewStudent([FromBody]StudentViewModel studentView)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            var studentDTO = new StudentDTO
            {
                // studentDTO.Id = studentView.Id;
                Name = studentView.Name,
                Surname = studentView.Surname
            };
            StudentService.CreateItem(studentDTO);

            return Ok();
        }

        // PUT: api/Student/5
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStudentById(int? id, [FromBody]StudentViewModel studentView)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            if (id == null)
                return BadRequest();


            StudentDTO item = await StudentService.GetItemAsync(id);       //get student by given id
           // item.Id = studentView.Id;
            item.Name = studentView.Name;
            item.Surname = studentView.Surname;
            StudentService.EditItem(item);

            return Ok();

        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            try
            {
                var studentDTO = StudentService.GetItemAsync(id);
                //if (studentDTO == null)
                //    throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

                StudentService.DeleteItem(id);
            }
            catch (System.Exception)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }



            return Ok("was deleted");
        }
    }

}

