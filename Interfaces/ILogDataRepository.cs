using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface ILogDataRepository : IRepositoryBase<LogData>
    {
        public bool LogDataToDatabase(string LogDataUserName,
                                      DataBaseOperation ThisDataBaseOperation,
                                      ModelDatabaseNumber ThisModelDatabaseNumber);
    }
}
