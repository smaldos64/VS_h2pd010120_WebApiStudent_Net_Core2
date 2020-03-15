using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Models;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.Models.DataManager.Extensions;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public CourseController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        // GET: api/Course
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Course> CourseList = this._repoWrapper.CourseRepositoryWrapper.FindAll();
            IEnumerable<LogData> LogDataList = this._repoWrapper.LogDataRepositoryWrapper.FindAll();
            IEnumerable<UserInfo> UserInfoList = this._repoWrapper.UserInfoRepositoryWrapper.FindAll();
            return Ok(CourseList);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        //[HttpGet("{id}", Name = "Get")]
        // Hvis man bruger Name attribut her, får man en kørselfejl, hvis man har flere 
        // Controllers i sit projekt => hvilket man jo typisk har !!!
        public IActionResult Get(int id)
        {
            Course Course_Object = this._repoWrapper.CourseRepositoryWrapper.GetCourseByCourseID(id);
           
            if (null == Course_Object)
            {
                return NotFound("The Course record couldn't be found.");
            }

            return Ok(Course_Object);
        }

        // POST: api/Course
        [HttpPost]
        public IActionResult Post([FromBody] Course Course_Object, string UserName, string Password)
        {
            int UserID = Const.OperationOkHigherValueThanHere;

            UserID = this._repoWrapper.UserInfoRepositoryWrapper.FindUserInDatabase(UserName, Password);

            if (Const.UserNotFound < UserID)
            {
                if (Course_Object.IsObjectNullGeneric())
                {
                    return BadRequest("Course is null.");
                }

                this._repoWrapper.CourseRepositoryWrapper.Create(Course_Object);

                this._repoWrapper.LogDataRepositoryWrapper.LogDataToDatabase(UserName, DataBaseOperation.SaveData_Enum, ModelDatabaseNumber.Course_Enum);

                return Ok(Course_Object.CourseID);
            }
            else
            {
                return Ok(Const.UserNotFound);
            }
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, string UserName, string Password, [FromBody] Course Course_Object)
        {
#if ASPNET_CORE_BUG 
            Course_Object.CourseID = (int)id;
#endif
            int UserID = Const.OperationOkHigherValueThanHere;

            UserID = this._repoWrapper.UserInfoRepositoryWrapper.FindUserInDatabase(UserName, Password);

            if (Const.UserNotFound < UserID)
            {
                if (Course_Object.IsObjectNullGeneric())
                {
                    return BadRequest("Course is null.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbCourse = this._repoWrapper.CourseRepositoryWrapper.GetCourseByCourseID(id);

                if (dbCourse.IsEmptyObjectGeneric())
                {
                    return Ok(Const.ObjectNotFound);
                }

                this._repoWrapper.CourseRepositoryWrapper.UpdateCourse(dbCourse, Course_Object);

                this._repoWrapper.LogDataRepositoryWrapper.LogDataToDatabase(UserName, DataBaseOperation.UpdateData_Enum, ModelDatabaseNumber.Course_Enum);

                return Ok(Const.UpdateOperationOk);
            }
            else
            {
                return Ok(Const.UserNotFound);
            }
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id, string UserName, string Password)
        {
            int UserID = Const.OperationOkHigherValueThanHere; 

            UserID = this._repoWrapper.UserInfoRepositoryWrapper.FindUserInDatabase(UserName, Password);

            if (Const.UserNotFound < UserID)
            {
                try
                {
                    Course Course_Object = this._repoWrapper.CourseRepositoryWrapper.GetCourseByCourseID(id);
                    if (Course_Object.IsEmptyObjectGeneric())
                    {
                        //return NotFound();
                        return Ok(Const.ObjectNotFound);
                    }

                    this._repoWrapper.CourseRepositoryWrapper.Delete(Course_Object);

                    this._repoWrapper.LogDataRepositoryWrapper.LogDataToDatabase(UserName, DataBaseOperation.DeleteData_Enum, ModelDatabaseNumber.Course_Enum);

                    //return NoContent();
                    return Ok(Const.DeleteOperationOk);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error");
                }
            }
            else
            {
                return Ok(Const.UserNotFound);
            }
        }
    }
}
