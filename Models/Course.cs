using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApiStudent_Net_Core2.Interfaces;

namespace WebApiStudent_Net_Core2.Models
{
    public class Course  
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }
    }
}