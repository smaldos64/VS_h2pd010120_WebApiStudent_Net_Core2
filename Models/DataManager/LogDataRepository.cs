﻿using System;
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
    }
}