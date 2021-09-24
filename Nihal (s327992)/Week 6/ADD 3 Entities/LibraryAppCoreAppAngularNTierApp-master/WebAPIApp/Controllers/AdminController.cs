using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Admin;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdmin_Service _Admin_Service;

        public AdminController(IAdmin_Service Admin_Service)
        {
            _Admin_Service = Admin_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAdmin(string name)
        {
            var result = await _Admin_Service.AddAdmin(name);
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
        public async Task<IActionResult> GetAllAdmins()
        {
            var result = await _Admin_Service.GetAllAdmins();
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
        public async Task<IActionResult> UpdateAdmin(Admin_Pass_Object Admin)
        {
            var result = await _Admin_Service.UpdateAdmin(Admin.id, Admin.name);
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
        public async Task<IActionResult> DeleteAdmin(Admin_Pass_Object Admin)
        {
            var result = await _Admin_Service.DeleteAdmin(Admin.id);
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
