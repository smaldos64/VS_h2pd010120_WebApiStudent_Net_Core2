using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.Interfaces;

namespace WebApiStudent_Net_Core2.Models.DataManager 
{
    public class UserInfoManager : IDataRepository<UserInfo>
    {
        readonly DatabaseContext _databaseContext;

        public UserInfoManager(DatabaseContext context)
        {
            this._databaseContext = context;
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return (this._databaseContext.UserInfos.ToList());
        }

        public UserInfo Get(long id)
        {
            return (this._databaseContext.UserInfos
                  .FirstOrDefault(u => u.UserInfoID == id));
        }

        public void Add(UserInfo entity)
        {
            this._databaseContext.UserInfos.Add(entity);
            this._databaseContext.SaveChanges();
        }

        public void Update(UserInfo userinfo, UserInfo entity)
        {
            userinfo.UserName = entity.UserName;
            userinfo.UserPassword = entity.UserPassword;

            this._databaseContext.SaveChanges();
        }

        public void Delete(UserInfo userinfo)
        {
            this._databaseContext.UserInfos.Remove(userinfo);
            this._databaseContext.SaveChanges();
        }
    }
}
