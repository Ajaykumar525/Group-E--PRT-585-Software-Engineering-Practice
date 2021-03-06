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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddTeacher(string name)
        {
            var result = await _Teacher_Service.AddTeacher(name);
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
            var result = await _Teacher_Service.GetAllTeacher();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTeacher(Teacher_Pass_Object Teacher)
        {
            var result = await _Teacher_Service.UpdateTeacher(Teacher.id, Teacher.name);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteTeacher(Teacher_Pass_Object Teacher)
        {
            var result = await _Teacher_Service.DeleteTeacher(Teacher.id);
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
