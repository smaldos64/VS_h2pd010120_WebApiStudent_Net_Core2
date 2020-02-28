using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public Course GetCourseByCourseID(long id)
        {
            Course Course_Object = new Course();

            try
            {
                //Course_Object = FindByCondition(c => c.CourseID.Equals(id))
                //.DefaultIfEmpty(new Course())
                //.FirstOrDefault();
                Course_Object = FindByCondition(course => course.CourseID == id)
                .DefaultIfEmpty(new Course())
                .FirstOrDefault();
            }
            catch (Exception error)
            {

            }

            return (Course_Object);
            }
    }
}
