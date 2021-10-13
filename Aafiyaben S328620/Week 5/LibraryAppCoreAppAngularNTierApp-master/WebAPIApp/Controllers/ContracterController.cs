﻿using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Contracter;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContracterController : ControllerBase
    {
        private IContracter_Service _Contracter_Service;

        public ContracterController(IContracter_Service Contracter_Service)
        {
            _Contracter_Service = Contracter_Service;
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AddContracter(string name, string contact, string email)
        {
            var result = await _Contracter_Service.AddContracter(name, contact, email);
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
        public async Task<IActionResult> GetAllContracters()
        {
            var result = await _Contracter_Service.GetAllContracter();
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
        public async Task<IActionResult> UpdateContracter(Contracter_Pass_Object Contracter)
        {
            var result = await _Contracter_Service.UpdateContracter(Contracter.id, Contracter.name, Contracter.contact, Contracter.email);
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
        public async Task<IActionResult> DeleteContracter(int id)
        {
            var result = await _Contracter_Service.DeleteContracter(id);
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
