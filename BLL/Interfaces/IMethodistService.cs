using BL.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IMethodistService
    {
        IEnumerable<StudentDTO> GetStudents(GroupDTO group);

        IEnumerable<TeacherDTO> GetTeachers();
        
    }
}
