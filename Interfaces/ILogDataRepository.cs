using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Models;
using WebApiStudent_Net_Core2.ViewModels;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface ILogDataRepository : IRepositoryBase<LogData>
    {
        public bool LogDataToDatabase(string LogDataUserName,
                                      DataBaseOperation ThisDataBaseOperation,
                                      ModelDatabaseNumber ThisModelDatabaseNumber);

        public List<VM_LogData> GetAllLogData();

        public VM_LogData GetLogDataByLogID(int Id);

        public List<VM_LogData> GetLogDataByUserName(string UserName);
    }
}
