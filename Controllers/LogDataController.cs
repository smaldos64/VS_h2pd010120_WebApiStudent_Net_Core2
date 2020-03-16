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
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    // Med routing sat op som i controlleren her, kan vi f.eks. have mere end
    // de 2 normale Get metoder. Det negative er, at vi så skal bruge ActionName på
    // alle requests ind ind til controlleren her !!!
    [ApiController]
    public class LogDataController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public LogDataController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/LogData/Get
        [HttpGet]
        [ActionName("Get")]
        public IActionResult Get()
        {
            List<VM_LogData> VM_LogDataList = this._repoWrapper.LogDataRepositoryWrapper.GetAllLogData();
          
            return Ok(VM_LogDataList);
        }

        // GET: api/LogData/GetLogDataByUserID/5
        [ActionName("GetLogDataByUserID")]
        [HttpGet("{id}")]
        public IActionResult GetLogDataByUserID(int id)
        {
            VM_LogData VM_LogData_Object = this._repoWrapper.LogDataRepositoryWrapper.GetLogDataByLogID(id);

            //if (LogData_Object.IsEmptyObjectGeneric())
            //{
            //    return Ok(Const.GenerateReturnNumberString(Const.ObjectNotFound));
            //}
            if (VM_LogData_Object.LogData_Object.LogDataID == Const.DataBaseZeroValue)
            {
                return Ok(Const.GenerateReturnNumberString(Const.ObjectNotFound));
            }

            return Ok(VM_LogData_Object);
        }

        // GET: api/LogData/GetLogDataByUserName/"UserName"
        [ActionName("GetLogDataByUserName")]
        [HttpGet("{UserName}")]
        public IActionResult GetLogDataByUserName(string UserName)
        {
            List<VM_LogData> VM_LogDataList = this._repoWrapper.LogDataRepositoryWrapper.GetLogDataByUserName(UserName);

            if (VM_LogDataList.IsEmptyObjectGeneric())
            {
                return Ok(Const.GenerateReturnNumberString(Const.ObjectNotFound));
            }

            return Ok(VM_LogDataList);
        }

        // POST: api/LogData/Post
        [ActionName("Post")]
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }

        // PUT: api/LogData/Put/5
        [ActionName("Put")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course Course_Object)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }

        // DELETE: api/LogData/Delete/5
        [ActionName("Delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }
    }
}
