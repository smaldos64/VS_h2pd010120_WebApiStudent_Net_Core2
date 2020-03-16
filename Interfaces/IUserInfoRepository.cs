using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface IUserInfoRepository : IRepositoryBase<UserInfo>
    {
        public IQueryable<UserInfo> FindAllUserInfo();

        public UserInfo GetUserByUserNameAndPassWord(string UserNanme, string Password);
        public int FindUserInDatabase(string UserNanme, string Password);
        public int CheckForUserInDatabase(int UserID, string UserName);
        public bool CheckForUserInDatabaseCreation(string UserName);
    }
}
