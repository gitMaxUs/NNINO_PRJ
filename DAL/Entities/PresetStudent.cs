using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PresetStudent
    {
        [Key]
        public int Id { get; set; }

        private bool studentIsSick;
        private bool studentHasReason;
        private bool studentHasNoReason;

        public int CountOfSkippedClasses { get; set; } = 0;
        public bool StudentWasNotOnTheLesson { get; set; }

        public bool StudentSick
        {
            get { return studentIsSick; }
            set
            {
                if (value == true)                  //chack whan this prop set false
                {
                    StudentWasNotOnTheLesson = true;
                    studentIsSick = true;
                    CountOfSkippedClasses++;
                }
                //else StudentWasNotOnTheLesson = false;
            }
        }
        public bool StudentHasReason
        {
            get { return studentHasReason; }
            set
            {
                if (value == true)
                {
                    StudentWasNotOnTheLesson = true;
                    studentHasReason = true;
                    CountOfSkippedClasses++;
                }
                //else StudentWasNotOnTheLesson = false;
            }
        }
        public bool StudentNotPressent
        {
            get { return studentHasNoReason; }
            set
            {
                if (value == true)
                {
                    StudentWasNotOnTheLesson = true;
                    studentHasNoReason = true;
                    CountOfSkippedClasses++;
                }
                //else StudentWasNotOnTheLesson = false;
            }
        }

        public DateTime Date { get; set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }

        public int? ConcreteLessonId { get; set; }
        public ConcreteLesson ConcreteLesson { get; set; }

        public string Note { get; set; }
    }
}
