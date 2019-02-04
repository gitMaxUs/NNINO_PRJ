using BLL.TransferObjects;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITeacherService
    {
        //bool AddEmptyStudent(int? _studentId);
              
        //void MarkPresentStudents(LessonDTO lesson, IEnumerable<StudentDTO> studentsList);

        //void MarkStudentAsSick(int? id);

        //void MarkStdentAsImportantReason(int? id);
        

        IEnumerable<StudentDTO> ShowStudentListBySelectedGroup(int? _groupId);

        IEnumerable<GroupDTO> GetGroups();
    }
}
