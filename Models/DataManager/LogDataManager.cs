using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.ViewModels;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class LogDataManager : IDataRepository<LogData>
    {
        readonly DatabaseContext _databaseContext;

        public LogDataManager(DatabaseContext context)
        {
            this._databaseContext = context;
        }

        //private IEnumerable<VM_LogData> ConvertLogDataList_To_VM_LogDataList(List<LogData> LogDataList)
        //{
        //    List<VM_LogData> VM_LogDataList = new List<VM_LogData>();
        //    VM_LogData VM_LogData_Object = new VM_LogData();

        //    foreach (LogData LogData_Object in LogDataList)
        //    {
        //        VM_LogData_Object = new VM_LogData();
        //        VM_LogData_Object.LogData_Object.LogDataID = LogData_Object.LogDataID;
        //        VM_LogData_Object.LogData_Object.LogDataDateTime = LogData_Object.LogDataDateTime;
        //        VM_LogData_Object.LogData_Object.LogDataUserName = LogData_Object.LogDataUserName;
        //        VM_LogData_Object.ThisDataBaseOperationString = Const.FindDataBaseOperationString(LogData_Object.ThisDataBaseOperation);
        //        VM_LogData_Object.ThisDataBaseTableSTring = Const.FindTableOperationString(LogData_Object.ThisModelDatabaseNumber);

        //        VM_LogDataList.Add(VM_LogData_Object);
        //    }

        //    return (VM_LogDataList);
        //}

        public IEnumerable<LogData> GetAll()
        {
            return (this._databaseContext.LogDatas.ToList());
        }

        //public IEnumerable<VM_LogData> GetAll_ViewModel()
        //{
        //    List<LogData> LogDataList = this._databaseContext.LogDatas.ToList();

        //    return (ConvertLogDataList_To_VM_LogDataList(LogDataList));
        //    //return (this._databaseContext.LogDatas.ToList());
        //}

        public LogData Get(long id)
        {
            return (this._databaseContext.LogDatas
                  .FirstOrDefault(l => l.LogDataID == id));
        }

        //public IEnumerable<LogData> Get(string UserName)
        //{
        //    return (this._databaseContext.LogDatas.Where(u => u.LogDataUserName == UserName).ToList());
        //}

        //public IEnumerable<VM_LogData> Get_ViewModel(string UserName)
        //{
        //    List<LogData> LogDataList = this._databaseContext.LogDatas.Where(u => u.LogDataUserName == UserName).ToList();

        //    return (ConvertLogDataList_To_VM_LogDataList(LogDataList));
        //}

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
