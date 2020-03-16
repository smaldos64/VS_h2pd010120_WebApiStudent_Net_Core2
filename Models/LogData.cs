using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApiStudent_Net_Core2.Data;

namespace WebApiStudent_Net_Core2.Models
{

    public enum DataBaseOperation
    {
        SaveData_Enum,
        UpdateData_Enum,
        DeleteData_Enum,
        ReadData_Enum
    }

    public enum ModelDatabaseNumber
    {
        Absence_Enum,
        Character13Scale_Enum,
        Character7Scale_Enum,
        ContactForm_Enum,
        Course_Enum,
        Education_Enum,
        EducationLine_Enum,
        User_Education_Character_Course_Collection_Enum,
        User_Eductaion_Time_Collection_Enum,
        UserFile_Enum,
        UserInfo_Enum
    }

    public class DataBaseOperationInfo
    {
        public DataBaseOperation ThisDataBaseOperation;
        public string ThisDataBaseOperationString;

        public DataBaseOperationInfo(DataBaseOperation ThisDataBaseOperation,
                                     string ThisDataBaseOperationString)
        {
            this.ThisDataBaseOperation = ThisDataBaseOperation;
            this.ThisDataBaseOperationString = ThisDataBaseOperationString;
        }
    }

    public class TableOperationInfo
    {
        public ModelDatabaseNumber ThisModelDatabaseNumber;
        public string ThisModelDatabaseNumberString;

        public TableOperationInfo(ModelDatabaseNumber ThisModelDatabaseNumber,
                                  string ThisModelDatabaseNumberString)
        {
            this.ThisModelDatabaseNumber = ThisModelDatabaseNumber;
            this.ThisModelDatabaseNumberString = ThisModelDatabaseNumberString;
        }
    }

    public class LogData
    {
        public int LogDataID { get; set; }

        public DateTime LogDataDateTime { get; set; }

        public string LogDataUserName { get; set; }

        public DataBaseOperation ThisDataBaseOperation { get; set; }

        public ModelDatabaseNumber ThisModelDatabaseNumber { get; set; }
    }
}