using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface IReturnCodesAndStringsRepository : IRepositoryBase<ReturnCodesAndStrings>
    //public interface IReturnCodesAndStringsRepository
    {
        public IQueryable<ReturnCodesAndStrings> FindAllReturnCodesAndStrings();
    }
}
