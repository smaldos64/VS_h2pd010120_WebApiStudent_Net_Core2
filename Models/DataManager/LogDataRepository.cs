using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class LogDataRepository : RepositoryBase<LogData>, ILogDataRepository
    {    
        public LogDataRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool LogDataToDatabase(string LogDataUserName,
                                      DataBaseOperation ThisDataBaseOperation,
                                      ModelDatabaseNumber ThisModelDatabaseNumber)
        {
            //int NumberOfLogDatasSaved = 0;
            LogData LogData_Object = new LogData();

            LogData_Object.LogDataDateTime = DateTime.Now;
            LogData_Object.LogDataUserName = LogDataUserName;
            LogData_Object.ThisDataBaseOperation = ThisDataBaseOperation;
            LogData_Object.ThisModelDatabaseNumber = ThisModelDatabaseNumber;

            this.Create(LogData_Object);

            return (true);
        }
    }
}
