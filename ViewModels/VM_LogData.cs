using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.ViewModels
{
    public class VM_LogData
    {
        public LogData LogData_Object { get; set; }
        public string ThisDataBaseOperationString { get; set; }
        public string ThisDataBaseTableSTring { get; set; }
    }
}
