using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface IDataRepositoryUserInfo<T> : IDataRepository<T>
    {
        //IEnumerable<T> GetAll_ViewModel();
        //IEnumerable<T> Get_ViewModel(string UserName);
        int FindUserInDatabase(string UserNanme, string Password);
        int CheckForUserInDatabase(int UserID, string UserName);
        bool CheckForUserInDatabaseCreation(string UserName);
    }
}
