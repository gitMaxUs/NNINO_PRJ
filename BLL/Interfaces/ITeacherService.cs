using BLL.TransferObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface ITeacherService
    {

        bool AddNewLesson(int? teacherId, string description);

        //void ChangeLessonsTopic();

        //void MarkPresentStudents(LessonDTO lesson, IEnumerable<StudentDTO> studentsList);

        //void MarkStudentAsSick(int? id);

        //void MarkStdentAsImportantReason(int? id);
         

        bool AddEmptyStudent(int? _studentId);

        

        IEnumerable<StudentDTO> ShowStudentListBySelectedGroup(GroupDTO group);

        IEnumerable<GroupDTO> ShowGroups();

    }
}
