using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.ViewModels;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.Models.DataManager.Extensions;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class LogDataRepository : RepositoryBase<LogData>, ILogDataRepository
    {    
        public LogDataRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }

        private List<VM_LogData> ConvertLogDataList_To_VM_LogDataList(List<LogData> LogDataList)
        {
            List<VM_LogData> VM_LogDataList = new List<VM_LogData>();
            VM_LogData VM_LogData_Object = new VM_LogData();

            foreach (LogData LogData_Object in LogDataList)
            {
                VM_LogData_Object = new VM_LogData();
                VM_LogData_Object.LogData_Object = new LogData();
                VM_LogData_Object.LogData_Object.LogDataID = LogData_Object.LogDataID;
                VM_LogData_Object.LogData_Object.LogDataDateTime = LogData_Object.LogDataDateTime;
                VM_LogData_Object.LogData_Object.LogDataUserName = LogData_Object.LogDataUserName;
                VM_LogData_Object.ThisDataBaseOperationString = Const.FindDataBaseOperationString(LogData_Object.ThisDataBaseOperation);
                VM_LogData_Object.ThisDataBaseTableSTring = Const.FindTableOperationString(LogData_Object.ThisModelDatabaseNumber);

                VM_LogDataList.Add(VM_LogData_Object);
            }

            return (VM_LogDataList);
        }

        public List<VM_LogData> GetAllLogData()
        {
            List<LogData> LogDataList = this.FindAll().ToList();

            List<VM_LogData> VM_LogDataList = this.ConvertLogDataList_To_VM_LogDataList(LogDataList);

            return (VM_LogDataList);
        }

        public List<VM_LogData> GetLogDataByUserName(string UserName)
        {
            List<LogData> LogDataList = this.FindByCondition(u => u.LogDataUserName == UserName);

            List<VM_LogData> VM_LogDataList = this.ConvertLogDataList_To_VM_LogDataList(LogDataList);

            return (VM_LogDataList);
        }

        public VM_LogData GetLogDataByLogID(int Id)
        {
            List<LogData> LogDataList = new List<LogData>();
            LogData LogData_Object = new LogData();
            List<VM_LogData> VM_LogDataList = new List<VM_LogData>();

            VM_LogDataList.Add(new VM_LogData());

            try
            {
                LogData_Object = FindByCondition(l => l.LogDataID == Id)
                .DefaultIfEmpty(new LogData())
                .FirstOrDefault();
            }
            catch (Exception error)
            {
                return (new VM_LogData());
            }

            if (!LogData_Object.IsEmptyObjectGeneric())
            {
                LogDataList.Add(LogData_Object);
                VM_LogDataList = this.ConvertLogDataList_To_VM_LogDataList(LogDataList);
            }
            
            return (VM_LogDataList[0]);
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
