﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class PresetStudentVIewModel
    {
        public bool Present { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public string Note { get; set; }


        public bool StudentSick { get; set; }
        public bool StudentHasReason { get; set; }
        public bool StudentNotPressent { get; set; }

        public bool StudentWasNotOnTheLesson { get; set; }
    }
}