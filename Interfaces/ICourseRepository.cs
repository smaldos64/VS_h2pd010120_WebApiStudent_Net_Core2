﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Course GetCourseByCourseID(long id);
        void UpdateCourse(Course dbCourse, Course Course_Object);
    }
}
