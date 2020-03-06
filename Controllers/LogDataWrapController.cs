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
using WebApiStudent_Net_Core2.ViewModels;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogDataWrapController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public LogDataWrapController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/LogDataWrap
        [HttpGet]
        public IActionResult Get()
        {
            List<VM_LogData> VM_LogDataList = this._repoWrapper.LogDataRepositoryWrapper.GetAllLogData();
          
            return Ok(VM_LogDataList);
        }

        // GET: api/LogDataWrap/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            VM_LogData LogData_Object = this._repoWrapper.LogDataRepositoryWrapper.GetLogDataByLogID(id);

            if (LogData_Object.IsEmptyObjectGeneric())
            {
                Ok(Const.ObjectNotFound + Const.FindReturnString(Const.ObjectNotFound));
            }

            return Ok(LogData_Object);
        }

        //[HttpGet("{UserName}")]
        //public IActionResult Get(string UsernName)
        //{
        //    List<VM_LogData> VM_LogDataList = this._repoWrapper.LogDataRepositoryWrapper.GetLogDataByUserName(UsernName);

        //    if (VM_LogDataList.IsEmptyObjectGeneric())
        //    {
        //        Ok(Const.ObjectNotFound + Const.FindReturnString(Const.ObjectNotFound));
        //    }

        //    return Ok(VM_LogDataList);
        //}

        // POST: api/LogDataWrap
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok(Const.FeatureNotImplemented);
        }

        // PUT: api/LogDataWrap/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok(Const.FeatureNotImplemented);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(Const.FeatureNotImplemented);
        }
    }
}
