using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Teacher;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacher_Service _Teacher_Service;

        public TeacherController(ITeacher_Service Teacher_Service)
        {
            _Teacher_Service = Teacher_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddTeacher(string name, Int32 experience)
        {
            var result = await _Teacher_Service.AddTeacher(name, experience);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var result = await _Teacher_Service.GetAllTeachers();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTeacher(int id, string name, int experience)
        {
            var result = await _Teacher_Service.UpdateTeacher(id, name, experience);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> DeleteTeacher(int Id)
        {
            var result = await _Teacher_Service.DeleteTeacher(Id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
