using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Models;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.ViewModels;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogDataController : ControllerBase
    {
        private readonly IDataRepository<LogData> _dataRepository;

        private IEnumerable<VM_LogData> ConvertLogDataList_To_VM_LogDataList(List<LogData> LogDataList)
        {
            List<VM_LogData> VM_LogDataList = new List<VM_LogData>();
            VM_LogData VM_LogData_Object = new VM_LogData();

            foreach (LogData LogData_Object in LogDataList)
            {
                VM_LogData_Object = new VM_LogData();
                VM_LogData_Object.LogData_Object.LogDataID = LogData_Object.LogDataID;
                VM_LogData_Object.LogData_Object.LogDataDateTime = LogData_Object.LogDataDateTime;
                VM_LogData_Object.LogData_Object.LogDataUserName = LogData_Object.LogDataUserName;
                VM_LogData_Object.ThisDataBaseOperationString = Const.FindDataBaseOperationString(LogData_Object.ThisDataBaseOperation);
                VM_LogData_Object.ThisDataBaseTableSTring = Const.FindTableOperationString(LogData_Object.ThisModelDatabaseNumber);

                VM_LogDataList.Add(VM_LogData_Object);
            }

            return (VM_LogDataList);
        }

        public LogDataController(IDataRepository<LogData> dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        // GET: api/LogData
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LogData> LogDataList = this._dataRepository.GetAll();

            IEnumerable<VM_LogData> LogDataListOut = ConvertLogDataList_To_VM_LogDataList(LogDataList.ToList());
            return Ok(LogDataListOut);
        }

        // GET: api/LogData/5
        [HttpGet("{UserName}", Name = "Get")]
        [ActionName("GetLogData")]
        public IActionResult Get(string UserName)
        {
            IEnumerable<LogData> LogDataList = this._dataRepository.GetAll();
            IEnumerable<LogData> LogDataListByUserName = LogDataList.Where(u => u.LogDataUserName == UserName).ToList();

            if (0 == LogDataListByUserName.Count())
            { 
                return NotFound("No LogData Saved by specified UserName");
            }

            IEnumerable<VM_LogData> LogDataListOut = ConvertLogDataList_To_VM_LogDataList(LogDataListByUserName.ToList());
            return Ok(LogDataListOut);
        }

        // POST: api/LogData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/LogData/5
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
