using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.Models.DataManager.Extensions;

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
                Course_Object = FindByCondition(c => c.CourseID == id)
                .DefaultIfEmpty(new Course())
                .FirstOrDefault();
                // (LTPE) Hmm ? virker ikke med den første syntaks
            }
            catch (Exception error)
            {

            }

            return (Course_Object);
        }

        public void UpdateCourse(Course dbCourse, Course Course_Object)
        {
           dbCourse.Map(Course_Object);
           this.Update(dbCourse);
        }
    }
}
