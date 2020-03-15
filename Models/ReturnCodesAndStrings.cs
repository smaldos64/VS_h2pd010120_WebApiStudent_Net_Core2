using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudent_Net_Core2.Models
{
    public class ReturnCodesAndStrings
    {
        public int ReturnCode { get; set; }

        public string ReturnString { get; set; }

        public ReturnCodesAndStrings()
        { }

        public ReturnCodesAndStrings(int ReturnCode, string ReturnString)
        {
            this.ReturnCode = ReturnCode;
            this.ReturnString = ReturnString;
        }
    }
}
