using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICourseRepository CourseRepositoryWrapper { get; }
        ILogDataRepository LogDataRepositoryWrapper { get; }
        IUserInfoRepository UserInfoRepositoryWrapper { get; }

        IReturnCodesAndStringsRepository ReturnCodesAndStringsWrapper { get; }
        void Save();
    }
}
