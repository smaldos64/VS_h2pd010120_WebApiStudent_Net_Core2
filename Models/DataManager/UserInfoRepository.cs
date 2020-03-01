using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.Tools;

namespace WebApiStudent_Net_Core2.Models.DataManager
{
    public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(DatabaseContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public int FindUserInDatabase(string UserNanme, string Password)
        {
            List<UserInfo> UserInfo_List = this.RepositoryContext.UserInfoes.ToList();
            Password = Crypto.Encrypt(Password);

            int UserCounter = 0;
            int UserID = Const.UserNotFound;

            while (UserCounter < UserInfo_List.Count)
            {
                if ((UserInfo_List[UserCounter].UserName == UserNanme) &&
                     (UserInfo_List[UserCounter].UserPassword == Password))
                {
                    UserID = UserInfo_List[UserCounter].UserInfoID;
                    break;
                }
                UserCounter++;
            }

            return (UserID);
        }

        public int CheckForUserInDatabase(int UserID, string UserName)
        {
            List<UserInfo> UserInfo_List = this.RepositoryContext.UserInfoes.Where(u => u.UserName.ToLower() == UserName.ToLower()).ToList();

            if ((UserInfo_List.Count > 1) || (1 == UserInfo_List.Count && UserInfo_List[0].UserInfoID != UserID))
            {
                return (Const.UserNameAlreadyPresent);
            }
            else
            {
                return (Const.UserNotFound);
            }
        }

        public bool CheckForUserInDatabaseCreation(string UserName)
        {
            List<UserInfo> UserInfo_List = this.RepositoryContext.UserInfoes.Where(u => u.UserName.ToLower() == UserName.ToLower()).ToList();

            if (UserInfo_List.Count > 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}
