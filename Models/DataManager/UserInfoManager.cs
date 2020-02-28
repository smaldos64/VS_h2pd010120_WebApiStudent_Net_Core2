using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Data;
using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Tools;
using WebApiStudent_Net_Core2.ConstDeclarations;

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
#if (DEBUG)
            List<UserInfo> UserInfoList = this._databaseContext.UserInfoes.ToList();

            for (int Counter = 0; Counter < UserInfoList.Count; Counter++)
            {
                UserInfoList[Counter].UserPassword = Crypto.Decrypt(UserInfoList[Counter].UserPassword);
            }
            return (UserInfoList);
#else
            return (this._databaseContext.UserInfos.ToList());
#endif
        }

        public UserInfo Get(long id)
        {
            return (this._databaseContext.UserInfoes
                  .FirstOrDefault(u => u.UserInfoID == id));
        }

        public void Add(UserInfo entity)
        {
#if (DEBUG)
            this._databaseContext.UserInfoes.Add(entity);
            this._databaseContext.SaveChanges();
#endif
        }

        public void Update(UserInfo userinfo, UserInfo entity)
        {
            userinfo.UserName = entity.UserName;
            userinfo.UserPassword = entity.UserPassword;

            this._databaseContext.SaveChanges();
        }

        public void Delete(UserInfo userinfo)
        {
#if (DEBUG)
            this._databaseContext.UserInfoes.Remove(userinfo);
            this._databaseContext.SaveChanges();
#endif
        }

        public int FindUserInDatabase(string UserNanme, string Password)
        {
            List<UserInfo> UserInfo_List = this._databaseContext.UserInfoes.ToList();
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
            List<UserInfo> UserInfo_List = this._databaseContext.UserInfoes.Where(u => u.UserName.ToLower() == UserName.ToLower()).ToList();

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
            List<UserInfo> UserInfo_List = this._databaseContext.UserInfoes.Where(u => u.UserName.ToLower() == UserName.ToLower()).ToList();

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
