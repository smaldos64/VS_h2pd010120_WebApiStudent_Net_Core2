﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiStudent_Net_Core2.Tools
{
    public class ErrorTojSonConverter
    {
        public List<object> ConvertErrorTojSonList(int ErrorNumber)
        {
            List<object> jSonList = new List<object>();

            var ListItem = new
            {
                ErrorNumber = ErrorNumber
            };
            jSonList.Add(ListItem);

            return (jSonList);
        }
    }
}