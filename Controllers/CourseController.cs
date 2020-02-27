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
    public class CourseController : ControllerBase
    {
        private readonly IDataRepository<Course> _dataRepository;

        public CourseController(IDataRepository<Course> dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        /// <summary>
        /// Returnerer info om alle Fag/Kurser. 
        /// </summary>
        /// <returns>
        /// Returnerer en liste af alle Fag/Kurser med tilhørende Fag/Kursus ID. Listen 
        /// returneres som en liste af jSon objekter, hvor hver enkelt jSon element 
        /// indeholder felterne : CourseID og CourseName.
        /// </returns>
        // GET: api/Course
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Course> CourseList = this._dataRepository.GetAll();
            return Ok(CourseList);
        }

        /// <summary>
        /// Returnerer info om ét specifikt Fag/Kursus udfra id.
        /// </summary>
        /// <param name="id">Fag/Kursus ID</param>
        /// <returns>
        /// Ét Kursus/Fag. Kurset/Faget returneres som et jSon element, som indeholder   
        /// felterne : CourseID og CourseName.
        /// Eller et json Objekt med felterne ErrorNumber og ErrorText hvor ErrorNumber har en værdi 
        /// mindre end 0. Se en oversigt over return koder i ReturnCodesAndStrings 
        /// eller klik her : <see cref="ReturnCodeAndReturnString"/>
        /// </returns>
        // GET: api/Course/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Course Course_Object = this._dataRepository.Get(id);

            if (null == Course_Object)
            {
                return NotFound("The Course record couldn't be found.");
            }

            return Ok(Course_Object);
        }

        /// <summary>
        /// Gemmer et nyt Fag/Kursus. Ved kald af denne funktionalitet skal man angive
        /// Brugernavn og Passsword. Kun brugere kendt af systemet kan udnytte denne funktionalitet.
        /// </summary>
        /// <param name="json_Object">json_Objekt er et objekt i jSon format. Det skal indeholde 
        /// data til funktionen med følgende felter specificeret : CourseName</param>
        /// <param name="Password">Password for nuværende bruger.</param>
        /// <param name="UserName">Brugernavn for nuværende bruger.</param>
        /// <returns>
        /// Id nummeret på det gemte Fag/Kursus. 
        /// Eller en retur kode med en værdi mindre end 0, hvis noget gik galt. 
        /// Se en oversigt over return koder i ReturnCodesAndStrings eller klik 
        /// her : <see cref="ReturnCodeAndReturnString"/>
        /// </returns>
        // POST: api/Course
        [HttpPost]
        public IActionResult Post([FromBody] Course Course_Object)
        {
            if (null == Course_Object)
            {
                return BadRequest("Course is null.");
            }

            this._dataRepository.Add(Course_Object);
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = Course_Object.CourseID },
            //      Course_Object);
            return Ok(Course_Object.CourseID);
        }

        /// <summary>
        /// Opdaterer ét Fag/Kursus udfra id. Ved kald af denne funktionalitet skal man 
        /// angive Brugernavn og Passsword. Kun brugere kendt af systemet kan udnytte denne 
        /// funktionalitet.
        /// </summary>
        /// <param name="json_Object">json_Objekt er et objekt i jSon format. Det skal indeholde 
        /// data til funktionen med følgende felter specificeret : CourseName</param>
        /// <param name="id">Fag/Kursus ID</param>
        /// <param name="Password">Password for nuværende bruger.</param>
        /// <param name="UserName">Brugernavn for nuværende bruger.</param>
        /// <returns>
        /// UpdateOperationOk (værdien 1) hvis Kursus/Fag er gemt ok. 
        /// Eller en retur kode med en værdi mindre end 0, hvis noget gik galt. 
        /// Se en oversigt over return koder i ReturnCodesAndStrings eller klik 
        /// her : <see cref="ReturnCodeAndReturnString"/>
        /// </returns>
        // PUT: api/Course/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Course Course_Object)
        {
            if (null == Course_Object)
            {
                return BadRequest("Course is null.");
            }

            Course Course_Object_ToUpdate = this._dataRepository.Get(id);
            if (null == Course_Object_ToUpdate)
            {
                return NotFound("The Course record couldn't be found.");
            }

            this._dataRepository.Update(Course_Object_ToUpdate, Course_Object);
            //return NoContent();
            return Ok(1);
        }

        /// <summary>
        /// Sletter ét specifikt Fag/Kursus udfra id. Ved kald af denne funktionalitet skal man 
        /// angive Brugernavn og Passsword. Kun brugere kendt af systemet kan udnytte denne 
        /// funktionalitet.
        /// </summary>
        /// <param name="id">Fag/Kursus ID</param>
        /// <param name="Password">Password for nuværende bruger.</param>
        /// <param name="UserName">Brugernavn for nuværende bruger.</param>
        /// <returns>
        /// DeleteOperationOk (værdien 3) hvis Fag/Kursus er slettet ok. 
        /// Eller en retur kode med en værdi mindre end 0, hvis noget gik galt. 
        /// Se en oversigt over return koder i ReturnCodesAndStrings eller klik 
        /// her : <see cref="ReturnCodeAndReturnString"/>
        /// </returns>
        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Course Course_Object = this._dataRepository.Get(id);
            if (null == Course_Object)
            {
                return NotFound("The Course record couldn't be found.");
            }

            this._dataRepository.Delete(Course_Object);
            //return NoContent();
            return Ok(3);
        }
    }
}
