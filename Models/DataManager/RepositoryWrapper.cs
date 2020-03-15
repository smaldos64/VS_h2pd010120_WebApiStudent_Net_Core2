using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _repoContext;
        private ICourseRepository _courseRepositoryWrapper;
        private ILogDataRepository _logDataRepositoryWrapper;
        private IUserInfoRepository _userInfoRepositoryWrapper;
        private IReturnCodesAndStringsRepository _returnCodesAndStringsWrapper;

        public ICourseRepository CourseRepositoryWrapper
        {
            get
            {
                if (_courseRepositoryWrapper == null)
                {
                    _courseRepositoryWrapper = new CourseRepository(_repoContext);
                }

                return _courseRepositoryWrapper;
            }
        }

        public ILogDataRepository LogDataRepositoryWrapper
        {
            get
            {
                if (_logDataRepositoryWrapper == null)
                {
                    _logDataRepositoryWrapper = new LogDataRepository(_repoContext);
                }

                return _logDataRepositoryWrapper;
            }
        }

        public IUserInfoRepository UserInfoRepositoryWrapper
        {
            get
            {
                if (_userInfoRepositoryWrapper == null)
                {
                    _userInfoRepositoryWrapper = new UserInfoRepository(_repoContext);
                }

                return _userInfoRepositoryWrapper;
            }
        }

        public IReturnCodesAndStringsRepository ReturnCodesAndStringsWrapper
        {
            get
            {
                if (_returnCodesAndStringsWrapper == null)
                {
                    _returnCodesAndStringsWrapper = new ReturnCodesAndStringsRepository(_repoContext);
                }

                return _returnCodesAndStringsWrapper;
            }
        }

        public RepositoryWrapper(DatabaseContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
