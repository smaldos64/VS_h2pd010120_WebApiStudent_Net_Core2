using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseWrapController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public CourseWrapController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/CourseWrap
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Course> CourseList = this._repoWrapper.CourseRepositoryWrapper.FindAll();
            IEnumerable<LogData> LogDataList = this._repoWrapper.LogDataRepositoryWrapper.FindAll();
            IEnumerable<UserInfo> UserInfoList = this._repoWrapper.UserInfoRepositoryWrapper.FindAll();
            return Ok(CourseList);
        }

        // GET: api/CourseWrap/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var Course_Object = this._repoWrapper.CourseRepositoryWrapper.GetCourseByCourseID(id);
           
            if (null == Course_Object)
            {
                return NotFound("The Course record couldn't be found.");
            }

            return Ok(Course_Object);
        }

        // POST: api/CourseWrap
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CourseWrap/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
