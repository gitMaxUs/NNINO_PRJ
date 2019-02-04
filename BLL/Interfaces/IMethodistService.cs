using BLL.TransferObjects;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    interface IMethodistService
    {
        IEnumerable<StudentDTO> GetStudents(GroupDTO group);

        IEnumerable<TeacherDTO> GetTeachers();

        //void NotifyStudentProblem(StudentDTO student);    

        IEnumerable<ProblemStudentDTO> GetStudentsWithProblems();       //returns student that have problem with visit lessons
    }
}
