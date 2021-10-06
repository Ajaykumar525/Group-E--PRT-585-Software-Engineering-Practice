using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Computer;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private IComputer_Service _Computer_Service;

        public ComputerController(IComputer_Service Computer_Service)
        {
            _Computer_Service = Computer_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddComputer(String computerName, String brand, String lastUser)
        {
            var result = await _Computer_Service.AddComputer(computerName, brand, lastUser);
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
        public async Task<IActionResult> GetAllComputers()
        {
            var result = await _Computer_Service.GetAllComputers();
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
        public async Task<IActionResult> UpdateComputer(Computer_Pass_Object computer)
        {
            var result = await _Computer_Service.UpdateComputer(computer.ComputerId, computer.ComputerName, computer.Brand, computer.LastUser);
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
        public async Task<IActionResult> DeleteComputer(Computer_Pass_Object book)
        {
            var result = await _Computer_Service.DeleteComputer(book.ComputerId);
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
