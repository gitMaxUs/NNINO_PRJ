using AutoMapper;
using BLL.Services;
using BLL.TransferObjects;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WEB.Models;
using WEB.UTIL;

namespace WEB_NNINO_2.Controllers
{
    //[Authorize(Roles = "Admin")]
    [RoutePrefix("api/Methodist")]
    public class MethodistController : ApiController
    {
        StudentService StudentService;

        public MethodistController()
        {
            StudentService = new StudentService(DBConnection.ConnectionString);     // connection string Deffault Connection
        }

        //IStudentService StudentService;
        //public MethodistController(IStudentService serv)
        //{
        //    StudentService = serv;
        //  //  StudentService = new StudentService(DBConnection.ConnectionString);     // connection string Deffault Connection
        //}

        [HttpGet]
        public IHttpActionResult GetListOfStudents()
        {
            IEnumerable<StudentDTO> studentDTO = StudentService.GetItems();

            if (studentDTO == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            return Ok(studentDTO);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("details/{id:int}")]
        public IHttpActionResult GetStudentById(int? id)
        {
            if (id == null)
                return NotFound();

            StudentDTO studentDTO = StudentService.GetItem(id);
            if (studentDTO == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            StudentViewModel studentView = mapper.Map<StudentDTO, StudentViewModel>(studentDTO);

            //  StudentService.CreateItem(await StudentService.GetItemAsync(id));

            return Ok(studentView);
        }

        //[HttpPost("upload")]
        [HttpPost]
        [Route("details/{id:int}")]
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

        public IHttpActionResult UpdateStudentById(int? id, [FromBody]StudentViewModel studentView)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            if (id == null)
                return BadRequest();


            StudentDTO item = StudentService.GetItem(id);       //get student by given id
                                                                // item.Id = studentView.Id;
            item.Name = studentView.Name;
            item.Surname = studentView.Surname;
            StudentService.EditItem(item);

            return Ok();

        }

        // DELETE: api/Student/5
        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            try
            {
                var studentDTO = StudentService.GetItem(id);
                if (studentDTO == null)
                    throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);

                Task.Run(() => StudentService.DeleteItem(id));
            }
            catch (System.Exception)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }



            return Ok("was deleted");
        }
    }

}

