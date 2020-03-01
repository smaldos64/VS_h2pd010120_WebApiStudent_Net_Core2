using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudent_Net_Core2.Models.DataManager.Extensions
{
    public static class CourseExtensions
    {
        public static void Map(this Course dbOwner, Course Course_Object)
        {
            dbOwner.CourseName = Course_Object.CourseName;
        }
    }
}
