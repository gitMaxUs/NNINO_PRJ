using AutoMapper;
using BL.Services;
using BL.TransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WEB.Models;
using WEB.UTIL;

namespace WEB.Controllers
{
    public class StudentController : ApiController
    {
        //IStudentService StudentService;
        //public StudentController(IStudentService svc)
        //{
        //    StudentService = svc;
        //}

        StudentService StudentService;

        public StudentController()
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

            var studentDTO = new StudentDTO();
            studentDTO.Id = studentView.Id;
            studentDTO.Name = studentView.Name;
            studentDTO.Surname = studentView.Surname;
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
            item.Id = studentView.Id;
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

//[Route("api/genres/{id:int}/games")]
//public IHttpActionResult GetgamesPerGenre(int? id)
//{
//    if (id == null)
//    {
//        return BadRequest();
//    }

//    var games = Mapper.Map<IEnumerable<studentDTO>, IEnumerable<GameViewModel>>(GameService.GetGamesperGenre(id.Value));
//    return Ok(games);

//}
//[Route("api/games/{id:int}/download")]
//public IHttpActionResult GetGame()
//{
//    var fileInfo = new FileInfo($"{HttpRuntime.AppDomainAppPath}/File/File.bin");
//    return !fileInfo.Exists
//        ? (IHttpActionResult)NotFound()
//        : new FileResult(fileInfo.FullName);
//}
//[Route("api/games/{id:int}/comments")]
//public IHttpActionResult GetGameComments(int? id)
//{
//    if (id == null)
//    {
//        return BadRequest();
//    }
//    var comments = Mapper.Map<IEnumerable<CommentDTO>, IEnumerable<CommentViewModel>>(GameService.GetCommentforGame(id.Value));
//    return Ok(comments);
//}
//[Route("api/games/{id}/comments")]
//public IHttpActionResult AddComment(int? id, CommentViewModel comment)
//{
//    if (id == null)
//    {
//        return BadRequest();
//    }

//    if (comment == null)
//    {
//        return BadRequest();
//    }
//    GameService.AddCommentToGame(id, Mapper.Map<CommentViewModel, CommentDTO>(comment));
//    return Ok();
//}
//[Route("api/comments/{id}/comments")]
//public IHttpActionResult AddCommentToComment(int? id, CommentViewModel comment)
//{
//    if (id == null)
//    {
//        return BadRequest();
//    }

//    if (comment == null)
//    {
//        return BadRequest();
//    }
//    GameService.AddCommentToComment(id.Value, Mapper.Map<CommentViewModel, CommentDTO>(comment));
//    return Ok();
//}



