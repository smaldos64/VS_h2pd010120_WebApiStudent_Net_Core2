using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IDataRepository<UserInfo> _dataRepository;

        public UserInfoController(IDataRepository<UserInfo> dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        // GET: api/UserInfo
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserInfo> UserInfoList = this._dataRepository.GetAll();
            return Ok(UserInfoList);
        }

        // GET: api/UserInfo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
