using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.Models.DataManager.Extensions;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class ReturnCodesAndStringsRepository : RepositoryBase<ReturnCodesAndStrings>, IReturnCodesAndStringsRepository
    //public class ReturnCodesAndStringsRepository : IReturnCodesAndStringsRepository
    {
        public ReturnCodesAndStringsRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IQueryable<ReturnCodesAndStrings> FindAll()
        {
            return (Const.ReturnCodesAndReturnStringsArray.AsQueryable());
        }
    }
}
