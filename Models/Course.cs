using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApiStudent_Net_Core2.Interfaces;
//using WebApiStudentData.ConstDeclarations;

namespace WebApiStudent_Net_Core2.Models
{
    public class Course  
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        //public static int CheckForCourseNameInCourse(string CourseName)
        //{
        //    DatabaseContext db = new DatabaseContext();

        //    List<Course> Course_List = db.Courses.ToList();
        //    int CourseCounter = 0;
        //    int CourseID = 0;

        //    while (CourseCounter < Course_List.Count)
        //    {
        //        if (Course_List[CourseCounter].CourseName.ToLower() == CourseName.ToLower())
        //        {
        //            CourseID = Course_List[CourseCounter].CourseID;
        //            return (Const.ObjectAlreadyPresent);
        //        }
        //        CourseCounter++;
        //    }

        //    return (Const.ObjectNotFound);
        //}
    }
}