using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Models;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.Models.DataManager.Extensions;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public UserInfoController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        // GET: api/UserInfo
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserInfo> UserInfoList = this._repoWrapper.UserInfoRepositoryWrapper.FindAllUserInfo();
            
            return Ok(UserInfoList);
        }

        // GET: api/UserInfo/5
        [HttpGet("{UserName}")]
        public IActionResult Get(string UserName, string Password)
        {
            UserInfo UserInfo_Object = this._repoWrapper.UserInfoRepositoryWrapper.GetUserByUserNameAndPassWord(UserName, Password);

            if (UserInfo_Object.IsEmptyObjectGeneric())
            {
                return Ok(Const.GenerateReturnNumberString(Const.UserNotFound));
            }

            return Ok(Const.GenerateReturnNumberString(Const.UserNameAlreadyPresent));
        }

        // POST: api/UserInfo
        [HttpPost]
        public IActionResult Post(string UserName, string Password)
        {
#if (DEBUG_USER)
            bool UserSavedOk;

            UserSavedOk = this._repoWrapper.UserInfoRepositoryWrapper.SaveUser(UserName, Password);

            if (true == UserSavedOk)
            {
                return Ok(Const.GenerateReturnNumberString(Const.SaveOperationOk));
            }
            else
            {
                return Ok(Const.GenerateReturnNumberString(Const.SaveOperationFailed));
            }
#else
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
#endif
        }

        // PUT: api/UserInfo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }

        // DELETE: api/UserInfo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }
    }
}
