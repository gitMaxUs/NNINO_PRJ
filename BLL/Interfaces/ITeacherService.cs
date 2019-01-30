using BL.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface ITeacherService
    {
        void NewLesson();

        void ChangeLessonsTopic();

        void ChackPresentStudents(LessonDTO lesson, IEnumerable<StudentDTO> studentsList);

        void ChackStudentAsSick(int? id);

        void ChackStdentAsImportantReason(int? id);

        void SetLessonsDate();


        IEnumerable<StudentDTO> ShowStudentListBySelectedGroup(GroupDTO group);

        IEnumerable<GroupDTO> ShowGroups();

    }
}
