using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Models;
using WebApiStudent_Net_Core2.ConstDeclarations;
using WebApiStudent_Net_Core2.Models.DataManager;
using WebApiStudent_Net_Core2.Models.DataManager.Extensions;

namespace WebApiStudent_Net_Core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnCodesAndStringsController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public ReturnCodesAndStringsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/ReturnCodesAndStrings
        [HttpGet]
        public IActionResult Get()
        {
            //Metode 1 : Inluderer Data specifik kode i Contreoller. Måske ikke en god ide !!!
            //List<ReturnCodesAndStrings> ReturnCodesAndStringsList = new List<ReturnCodesAndStrings>();

            //foreach (ReturnCodesAndStrings ReturnCodeAndReturnString_Object in Const.ReturnCodesAndReturnStrings)
            //{
            //    ReturnCodesAndStringsList.Add((ReturnCodesAndStrings)ReturnCodeAndReturnString_Object);
            //}

            //Metode 2 : Brug "Database" modellen selvom data i datte tilfælde ikke bliver hentet fra den 
            // fysiske database men fra et konstant Array defineret i Const.cs filen. Dette vil virke,
            // hvis blot vi sørger for at lave en Override af FindAll (den metode vi bruger herunder) metoden 
            // fra RepositotyBase.cs, da metoden FindAll her arbejder på den fysiske databse. I tilfældet her
            // skal vi således blot konvertere vores svar fra vores konstante Array til en IQueryAble.

            IEnumerable<ReturnCodesAndStrings> ReturnCodesAndStringsList = this._repoWrapper.ReturnCodesAndStringsWrapper.FindAllReturnCodesAndStrings();

            return Ok(ReturnCodesAndStringsList);
        }

        // GET: api/ReturnCodesAndStrings/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }

        // POST: api/ReturnCodesAndStrings
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }

        // PUT: api/ReturnCodesAndStrings/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course Course_Object)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(Const.GenerateReturnNumberString(Const.FeatureNotImplemented));
        }
    }
}
