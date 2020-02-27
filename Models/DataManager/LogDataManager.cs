using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.Interfaces;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class LogDataManager : IDataRepository<LogData>
    {
        readonly DatabaseContext _databaseContext;

        public LogDataManager(DatabaseContext context)
        {
            this._databaseContext = context;
        }

        public IEnumerable<LogData> GetAll()
        {
            return (this._databaseContext.LogDatas.ToList());
        }

        public LogData Get(long id)
        {
            return (this._databaseContext.LogDatas
                  .FirstOrDefault(l => l.LogDataID == id));
        }

        public void Add(LogData entity)
        {
            this._databaseContext.LogDatas.Add(entity);
            this._databaseContext.SaveChanges();
        }

        public void Update(LogData logdata, LogData entity)
        {
            logdata.LogDataDateTime = entity.LogDataDateTime;
            logdata.LogDataUserName = entity.LogDataUserName;
            logdata.ThisDataBaseOperation = entity.ThisDataBaseOperation;
            logdata.ThisModelDatabaseNumber = entity.ThisModelDatabaseNumber;

            this._databaseContext.SaveChanges();
        }

        public void Delete(LogData logdata)
        {
            this._databaseContext.LogDatas.Remove(logdata);
            this._databaseContext.SaveChanges();
        }
    }
}
