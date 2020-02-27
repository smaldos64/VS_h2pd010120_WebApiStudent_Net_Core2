using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiStudent_Net_Core2.Models;
using WebApiStudent_Net_Core2.Interfaces;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IDataRepository<Course> _dataRepository;

        public CourseController(IDataRepository<Course> dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        // GET: Course
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Course> courses = _dataRepository.GetAll();
            return Ok(courses);

            //List<object> jSonList = new List<object>();
            //List<Course> Course_List = new List<Course>();

            //Course_List = db.Courses.ToList();

            //foreach (Course Course_Object in Course_List)
            //{
            //    var ListItem = new
            //    {
            //        CourseID = Course_Object.CourseID,
            //        CourseName = Course_Object.CourseName
            //    };
            //    jSonList.Add(ListItem);
            //}
            //return (jSonList);
        }

        // GET: api/Course
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Course course = _dataRepository.Get(id);

            if (null == course)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course is null.");
            }

            _dataRepository.Add(course);
            return CreatedAtRoute(
                  "Get",
                  new { Id = course.CourseID },
                  course);
        }

        // PUT: api/course/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Course course)
        {
            if (null == course)
            {
                return BadRequest("Course is null.");
            }

            Course courseToUpdate = _dataRepository.Get(id);
            if (null == courseToUpdate)
            {
                return NotFound("The Course record couldn't be found.");
            }

            _dataRepository.Update(courseToUpdate, course);
            return NoContent();
        }

        // DELETE: api/course/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Course course = _dataRepository.Get(id);
            if (null == course)
            {
                return NotFound("The Course record couldn't be found.");
            }

            _dataRepository.Delete(course);
            return NoContent();
        }
    }
}