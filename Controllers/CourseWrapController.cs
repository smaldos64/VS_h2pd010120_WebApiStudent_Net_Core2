﻿using System;
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
            Course Course_Object = this._repoWrapper.CourseRepositoryWrapper.GetCourseByCourseID(id);
           
            if (null == Course_Object)
            {
                return NotFound("The Course record couldn't be found.");
            }

            return Ok(Course_Object);
        }

        // POST: api/CourseWrap
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

                return Ok(Course_Object.CourseID);
            }
            else
            {
                return Ok(Const.UserNotFound);
            }
        }

        // PUT: api/CourseWrap/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Course Course_Object, string UserName, string Password)
        {
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

                return Ok(Const.UpdateOperationOk);
            }
            else
            {
                return Ok(Const.UserNotFound);
            }
        }

        // DELETE: api/ApiWithActions/5
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
