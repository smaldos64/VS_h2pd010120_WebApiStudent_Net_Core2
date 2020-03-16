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
        [HttpGet("{id}")]
        //[HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string UserName, string Password)
        {
            return Ok(Const.DataBaseZeroValue);
        }

        // POST: api/UserInfo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UserInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/UserInfo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
