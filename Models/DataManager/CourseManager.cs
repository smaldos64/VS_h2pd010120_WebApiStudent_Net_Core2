﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.Interfaces;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class CourseManager : IDataRepository<Course>
    {
        readonly DatabaseContext _databaseContext;

        public CourseManager(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _databaseContext.Courses.ToList();
        }

        public Course Get(long id)
        {
            return _databaseContext.Courses
                  .FirstOrDefault(c => c.CourseID == id);
        }

        public void Add(Course entity)
        {
            _databaseContext.Courses.Add(entity);
            _databaseContext.SaveChanges();
        }

        public void Update(Course course, Course entity)
        {
            course.CourseName = entity.CourseName;

            _databaseContext.SaveChanges();
        }

        public void Delete(Course course)
        {
            _databaseContext.Courses.Remove(course);
            _databaseContext.SaveChanges();
        }
    }
}
